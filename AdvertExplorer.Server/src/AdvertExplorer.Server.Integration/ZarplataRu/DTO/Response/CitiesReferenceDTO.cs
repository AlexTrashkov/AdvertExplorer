using System.Collections.Generic;

namespace AdvertExplorer.Server.Integration.ZarplataRu.DTO.Response
{
	internal sealed class CitiesReferenceDTO
	{
		public int id { get; set; }
		public string title { get; set; }
		public List<object> districts { get; set; }
		public List<object> subways { get; set; }
	}
}