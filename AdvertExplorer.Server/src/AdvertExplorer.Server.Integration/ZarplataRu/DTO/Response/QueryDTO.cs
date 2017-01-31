namespace AdvertExplorer.Server.Integration.ZarplataRu.DTO.Response
{
	internal sealed class QueryDTO
	{
		public int visibility_type { get; set; }
		public string average_salary { get; set; }
		public string experience_length_id { get; set; }
		public string geo_id { get; set; }
		public string q { get; set; }
		public string search_type { get; set; }
		public string searched_q { get; set; }
	}
}