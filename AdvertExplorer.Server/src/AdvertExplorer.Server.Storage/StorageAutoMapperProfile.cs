using System;
using System.Linq;
using AdvertExplorer.Server.Domain.Entities;
using AdvertExplorer.Server.Domain.ValueObjects;
using AdvertExplorer.Server.Storage.DTO;
using AutoMapper;

namespace AdvertExplorer.Server.Storage
{
	public sealed class StorageAutoMapperProfile : Profile
	{
		public StorageAutoMapperProfile()
		{
			CreateMap<Query, QueryDTO>();
			CreateMap<QueryDTO, Query>();

			CreateMap<Resume, ResumeDTO>().ConvertUsing(x =>
			{
				var rubricsAsStrings = x.Rubrics.Select(rubric => ((int) rubric).ToString());
				var rubricsAsString = string.Join(",", rubricsAsStrings);

				return new ResumeDTO
				{
					Id = x.Id,
					Age = x.Age,
					City = x.City,
					Salary = x.Salary,
					Description = x.Description,
					EducationType = x.EducationType,
					Experience = x.Experience,
					Institution = x.Institution,
					JobTitle = x.JobTitle,
					Name = x.Name,
					PhotoUri = x.PhotoUri,
					Specialty = x.Specialty,
					WorkingType = x.WorkingType,
					Rubrics = rubricsAsString
				};
			});

			//TODO need fix this code and use it instead above
			//CreateMap<Resume, ResumeDTO>()
			//	.ForMember(dto => dto.Rubrics,
			//		config => config.ResolveUsing(entity =>
			//		{
			//			var rubricsAsStrings = entity.Rubrics.Select(rubric => ((int) rubric).ToString());
			//			var rubricsAsString = string.Join(",", rubricsAsStrings);

			//			return rubricsAsString;
			//		}));

			CreateMap<ResumeDTO, Resume>().ConvertUsing(x =>
			{
				var rubrics = x.Rubrics
					.Split(',')
					.Select(rubric => (Rubric) Convert.ToInt32(rubric))
					.ToArray();

				return new Resume(
					x.Id,
					x.City,
					rubrics,
					x.JobTitle,
					x.Name,
					x.Age,
					x.Institution,
					x.PhotoUri,
					x.Specialty,
					x.Description,
					x.Experience,
					x.EducationType,
					x.WorkingType,
					x.Salary);
			});

			//TODO need fix this code and use it instead above
			//CreateMap<ResumeDTO, Resume>()
			//	.ForMember(entity => entity.Rubrics,
			//		opt => opt.ResolveUsing(
			//			dto =>
			//			{
			//				var rubricsAsStrings = dto.Rubrics.Split(',');
			//				var rubrics = rubricsAsStrings
			//					.Select(rubric => (Rubric) Convert.ToInt32(rubric))
			//					.ToArray();

			//				return rubrics;
			//			}));
		}
	}
}