using System.Collections.Generic;
using System.Linq;
using AdvertExplorer.Server.Domain.Entities;
using AdvertExplorer.Server.Domain.Repositories;
using AdvertExplorer.Server.Storage.DTO;
using AutoMapper;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace AdvertExplorer.Server.Storage.Repositories
{
	internal sealed class ResumeRepository : IResumeRepository
	{
		private readonly IMapper _mapper;

		public ResumeRepository([NotNull] IMapper mapper)
		{
			_mapper = mapper;
		}

		public IReadOnlyCollection<Resume> GetBy(Query query)
		{
			using (var context = new AdvertExplorerContext())
			{
				return context.Resumes
					.Where(x =>
						x.City == query.Region &&
						(query.Experience == null || x.Experience == query.Experience) &&
						(query.Rubric == null || x.Rubrics.Contains(((int) query.Rubric).ToString())) &&
						(query.AgeMax == null || x.Age < query.AgeMax) &&
						(query.AgeMin == null || x.Age > query.AgeMin) &&
						(query.AgeMin == null || x.Age > query.AgeMin) &&
						(query.SearchString == null ||
						 (x.JobTitle.Contains(query.SearchString) ||
						  x.Name.Contains(query.SearchString) ||
						  x.Id.ToString().Contains(query.SearchString))))
					.Select(x => _mapper.Map<ResumeDTO, Resume>(x))
					.ToArray();
			}
		}

		public void SaveOrUpdateRange(IReadOnlyCollection<Resume> resumes)
		{
			using (var context = new AdvertExplorerContext())
			{
				foreach (var resumeDto in resumes.Select(_mapper.Map<Resume, ResumeDTO>))
				{
					var oldResume = context.Resumes
						.AsNoTracking()
						.FirstOrDefault(x => x.Id == resumeDto.Id);

					if (oldResume == null)
					{
						context.Resumes.Add(resumeDto);
					}
					else
					{
						context.Entry(oldResume).Context.Update(resumeDto);
					}
				}

				context.SaveChanges();
			}
		}
	}
}