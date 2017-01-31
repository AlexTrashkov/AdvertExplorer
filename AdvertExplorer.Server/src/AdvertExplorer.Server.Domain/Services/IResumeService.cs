using System.Collections.Generic;
using AdvertExplorer.Server.Domain.Entities;
using AdvertExplorer.Server.Domain.ValueObjects;
using JetBrains.Annotations;

namespace AdvertExplorer.Server.Domain.Services
{
	public interface IResumeService
	{
		[NotNull]
		IReadOnlyCollection<Resume> GetBy(
			Region region,
			[CanBeNull] Rubric? rubric = null,
			[CanBeNull] Experience? experience = null,
			[CanBeNull] uint? salary = null,
			[CanBeNull] uint? maxAge = null,
			[CanBeNull] uint? minAge = null,
			[CanBeNull] string seachString = null);
	}
}