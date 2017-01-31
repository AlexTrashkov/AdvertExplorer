namespace AdvertExplorer.Server.Integration.ZarplataRu.DTO.Response
{
	internal sealed class ContactDTO
	{
		public string name { get; set; }
		public string firstname { get; set; }
		public string patronymic { get; set; }
		public string street { get; set; }
		public string building { get; set; }
		public string room { get; set; }
		public SubwayDTO subway { get; set; }
		public DistrictDTO district { get; set; }
		public object address_description { get; set; }
		public object address { get; set; }
		public CityDTO city { get; set; }
		public object icq { get; set; }
		public string skype { get; set; }
		public string url { get; set; }
		public object facebook { get; set; }
		public object moi_krug { get; set; }
		public object linkedin { get; set; }
		public object twitter { get; set; }
		public object vk { get; set; }
		public bool use_messages { get; set; }
	}
}