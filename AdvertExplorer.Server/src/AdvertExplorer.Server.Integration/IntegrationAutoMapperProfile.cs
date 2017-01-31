using System.Linq;
using AdvertExplorer.Server.Domain.Entities;
using AdvertExplorer.Server.Domain.ValueObjects;
using AdvertExplorer.Server.Integration.ZarplataRu.DTO.Request;
using AdvertExplorer.Server.Integration.ZarplataRu.DTO.Response;
using AutoMapper;
using RubricDTO = AdvertExplorer.Server.Integration.ZarplataRu.DTO.Request.RubricDTO;

namespace AdvertExplorer.Server.Integration
{
	public sealed class IntegrationAutoMapperProfile : Profile
	{
		public IntegrationAutoMapperProfile()
		{
			CreateMap<Query, ZarplataRuApiRequest>();

			CreateMap<ResumeDTO, Resume>().ConvertUsing(dto =>
			{
				var rubrics = dto.rubrics
					.Select(x => (RubricDTO) x.id)
					.Select(Mapper.Map<RubricDTO, Rubric>)
					.ToArray();

				var region = Mapper.Map<RegionDTO, Region>((RegionDTO) dto.cities_references.First().id);

				var experience = dto.experience_length != null
					? Mapper.Map<ExperienceDTO, Experience?>((ExperienceDTO) dto.experience_length.id)
					: null;

				var salaryWithoutFormatting = dto.salary
					.Replace("руб.", "")
					.Replace(" ", "");

				var salary = TryParceUintNullable(salaryWithoutFormatting);

				return new Resume(
					dto.id,
					region,
					rubrics,
					dto.header,
					dto.contact?.name,
					dto.age,
					dto.institution,
					dto.photo?.url,
					dto.education_specialty,
					dto.education_description,
					experience,
					dto.education?.title,
					dto.working_type?.title,
					salary);
			});
		}

		private uint? TryParceUintNullable(string value)
		{
			uint result;

			return uint.TryParse(value, out result)
				? (uint?) result
				: null;
		}
	}
}