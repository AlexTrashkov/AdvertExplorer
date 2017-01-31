using System.Collections.Generic;
using AdvertExplorer.Server.Domain.Entities;
using JetBrains.Annotations;

namespace AdvertExplorer.Server.Domain.Services
{
	public interface IExternalResumeApiClient
	{
		[NotNull]
		IReadOnlyCollection<Resume> LoadResumes([NotNull] Query query);
	}
}