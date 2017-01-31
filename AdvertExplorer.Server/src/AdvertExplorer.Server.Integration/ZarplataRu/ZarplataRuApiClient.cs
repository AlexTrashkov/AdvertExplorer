using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using AdvertExplorer.Server.Domain.Entities;
using AdvertExplorer.Server.Domain.Services;
using AdvertExplorer.Server.Integration.ZarplataRu.DTO.Request;
using AdvertExplorer.Server.Integration.ZarplataRu.DTO.Response;
using AutoMapper;
using JetBrains.Annotations;
using Newtonsoft.Json;

namespace AdvertExplorer.Server.Integration.ZarplataRu
{
	public sealed class ZarplataRuApiClient : IExternalResumeApiClient
	{
		private readonly IMapper _mapper;

		public ZarplataRuApiClient([NotNull] IMapper mapper)
		{
			_mapper = mapper;
		}

		public IReadOnlyCollection<Resume> LoadResumes(Query query)
		{
			var request = _mapper.Map<Query, ZarplataRuApiRequest>(query);
			var requestString = CreateRequestString(request);

			using (var client = new HttpClient())
			{
				var loadResumesTask = client.GetAsync(requestString);
				loadResumesTask.Wait(); //TODO maybe use async/await?
				var response = loadResumesTask.Result;

				var readContentTask = response.Content.ReadAsStringAsync();
				readContentTask.Wait();
				var resultJsonString = readContentTask.Result;

				var dto = JsonConvert.DeserializeObject<ZarplataRuApiResponse>(resultJsonString);

				var resumes = dto.resumes
					.Select(_mapper.Map<ResumeDTO, Resume>)
					.ToArray();

				return resumes;
			}
		}

		private string CreateRequestString(ZarplataRuApiRequest request)
		{
			var requestString =
				$"https://api.zp.ru/v1/resumes/?" +
				$"geo_id={(int) request.Region}&" +
				$"limit=100&" +
				$"state=1&";

			if (request.Rubric != null)
				requestString += $"&rubric_id={(int) request.Rubric}";

			if (request.Experience != null)
				requestString += $"&experience_length_id={(int) request.Experience}";

			if (request.AgeMax != null)
				requestString += $"&age_max={request.AgeMax}";

			if (request.AgeMin != null)
				requestString += $"&age_min={request.AgeMin}";

			if (request.SearchString != null)
				requestString += $"&q={request.SearchString}";

			if (request.Salary != null)
				requestString += $"&salary={request.Salary}";

			return requestString;
		}
	}
}