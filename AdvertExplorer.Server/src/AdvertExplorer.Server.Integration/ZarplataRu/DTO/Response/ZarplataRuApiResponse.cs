using System.Collections.Generic;

namespace AdvertExplorer.Server.Integration.ZarplataRu.DTO.Response
{
	internal sealed class ZarplataRuApiResponse
	{
		public MetadataDTO metadata { get; set; }
		public List<ResumeDTO> resumes { get; set; }
	}
}