namespace AdvertExplorer.Server.Integration.ZarplataRu.DTO.Response
{
	internal sealed class LastLogDTO
	{
		public int reason_id { get; set; }
		public object reason { get; set; }
		public int user_id { get; set; }
		public CreatedAtDTO created_at { get; set; }
	}
}