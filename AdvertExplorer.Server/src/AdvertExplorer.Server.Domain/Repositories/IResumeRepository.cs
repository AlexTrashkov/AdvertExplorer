using System.Collections.Generic;
using AdvertExplorer.Server.Domain.Entities;
using JetBrains.Annotations;

namespace AdvertExplorer.Server.Domain.Repositories
{
	public interface IResumeRepository
	{
		[NotNull]
		IReadOnlyCollection<Resume> GetBy([NotNull] Query query);

		void SaveOrUpdateRange([NotNull] IReadOnlyCollection<Resume> resumes);
	}
}