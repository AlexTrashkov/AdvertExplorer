using JetBrains.Annotations;

namespace AdvertExplorer.Server.Integration.ZarplataRu.DTO.Request
{
	internal sealed class ZarplataRuApiRequest
	{
		public RegionDTO Region { get; set; }

		[CanBeNull]
		public RubricDTO? Rubric { get; set; }

		[CanBeNull]
		public ExperienceDTO? Experience { get; set; }

		[CanBeNull]
		public uint? Salary { get; set; }

		[CanBeNull]
		public uint? AgeMax { get; set; }

		[CanBeNull]
		public uint? AgeMin { get; set; }

		[CanBeNull]
		public string SearchString { get; set; }
	}
}