namespace AdvertExplorer.Server.Integration.ZarplataRu.DTO.Response
{
	internal sealed class MetadataDTO
	{
		public QueryDTO query { get; set; }
		public int average_salary { get; set; }
		public ResultsetDTO resultset { get; set; }
	}
}