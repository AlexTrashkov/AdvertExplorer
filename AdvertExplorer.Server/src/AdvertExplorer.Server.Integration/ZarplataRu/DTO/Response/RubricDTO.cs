using System.Collections.Generic;

namespace AdvertExplorer.Server.Integration.ZarplataRu.DTO.Response
{
	internal sealed class RubricDTO
	{
		public int id { get; set; }
		public string title { get; set; }
		public List<SpecialityDTO> specialities { get; set; }
	}
}