using System;
using System.Collections.Generic;
using AdvertExplorer.Server.Domain.Entities;
using AdvertExplorer.Server.Domain.Repositories;
using AdvertExplorer.Server.Domain.ValueObjects;
using JetBrains.Annotations;

namespace AdvertExplorer.Server.Domain.Services.Implementations
{
	public sealed class ResumeService : IResumeService
	{
		private readonly IResumeRepository _resumeRepository;
		private readonly IQueryRepository _queryRepository;
		private readonly IExternalResumeApiClient _externalResumeApiClient;

		public ResumeService(
			[NotNull] IResumeRepository resumeRepository,
			[NotNull] IQueryRepository queryRepository,
			[NotNull] IExternalResumeApiClient externalResumeApiClient)
		{
			_resumeRepository = resumeRepository;
			_queryRepository = queryRepository;
			_externalResumeApiClient = externalResumeApiClient;
		}

		public IReadOnlyCollection<Resume> GetBy(
			Region region,
			Rubric? rubric,
			Experience? experience,
			uint? salary,
			uint? maxAge,
			uint? minAge,
			string seachString)
		{
			var cachedQuery = _queryRepository.FindBy(region, rubric, experience, salary, maxAge, minAge, seachString);

			if (cachedQuery == null)
			{
				var createdQuery = new Query(region, rubric, experience, salary, maxAge, minAge, seachString);
				_queryRepository.Save(createdQuery);

				var loadedResumes = _externalResumeApiClient.LoadResumes(createdQuery);
				_resumeRepository.SaveOrUpdateRange(loadedResumes);

				return loadedResumes;
			}

			if (cachedQuery.IsActual)
			{
				return _resumeRepository.GetBy(cachedQuery);
			}
			else
			{
				cachedQuery.LastUpdateDate = DateTime.UtcNow;
				_queryRepository.Update(cachedQuery);

				var loadedResumes = _externalResumeApiClient.LoadResumes(cachedQuery);
				_resumeRepository.SaveOrUpdateRange(loadedResumes);

				return loadedResumes;
			}
		}
	}
}