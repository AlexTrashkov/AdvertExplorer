using AdvertExplorer.Server.Domain.Entities;
using AdvertExplorer.Server.Domain.ValueObjects;
using JetBrains.Annotations;

namespace AdvertExplorer.Server.Domain.Repositories
{
	public interface IQueryRepository
	{
		[CanBeNull]
		Query FindBy(
			Region region,
			[CanBeNull] Rubric? rubric = null,
			[CanBeNull] Experience? experience = null,
			[CanBeNull] uint? salary = null,
			[CanBeNull] uint? maxAge = null,
			[CanBeNull] uint? minAge = null,
			[CanBeNull] string seachString = null);

		void Save([NotNull] Query createdQuery);
		void Update([NotNull] Query updatedQuery);
	}
}