using System.Linq;
using AdvertExplorer.Server.Domain.Entities;
using AdvertExplorer.Server.Domain.Repositories;
using AdvertExplorer.Server.Domain.ValueObjects;
using AdvertExplorer.Server.Storage.DTO;
using AutoMapper;
using JetBrains.Annotations;

namespace AdvertExplorer.Server.Storage.Repositories
{
	internal sealed class QueryRepository : IQueryRepository
	{
		private readonly IMapper _mapper;

		public QueryRepository([NotNull] IMapper mapper)
		{
			_mapper = mapper;
		}

		public Query FindBy(Region region,
			Rubric? rubric,
			Experience? experience,
			uint? salary,
			uint? maxAge,
			uint? minAge,
			string seachString)
		{
			using (var context = new AdvertExplorerContext())
			{
				var dto = context.Queries.FirstOrDefault(x =>
					x.Region == region &&
					x.Rubric == rubric &&
					x.Experience == experience &&
					x.Salary == salary &&
					x.AgeMax == maxAge &&
					x.AgeMin == minAge &&
					x.SearchString == seachString);

				return dto != null
					? _mapper.Map<QueryDTO, Query>(dto)
					: null;
			}
		}

		public void Save(Query createdQuery)
		{
			var dto = _mapper.Map<Query, QueryDTO>(createdQuery);

			using (var context = new AdvertExplorerContext())
			{
				context.Queries.Add(dto);
				context.SaveChanges();
			}
		}

		public void Update(Query updatedQuery)
		{
			var dto = _mapper.Map<Query, QueryDTO>(updatedQuery);

			using (var context = new AdvertExplorerContext())
			{
				context.Queries.Update(dto);
				context.SaveChanges();
			}
		}
	}
}