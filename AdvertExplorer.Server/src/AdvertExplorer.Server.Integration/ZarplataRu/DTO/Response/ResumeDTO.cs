using System.Collections.Generic;

namespace AdvertExplorer.Server.Integration.ZarplataRu.DTO.Response
{
	internal sealed class ResumeDTO
	{
		public int id { get; set; }
		public int owner_id { get; set; }
		public int? wanted_salary { get; set; }
		public int? wanted_salary_rub { get; set; }
		public uint? age { get; set; }
		public string header { get; set; }
		public string personal_qualities { get; set; }
		public string institution { get; set; }
		public string education_specialty { get; set; }
		public string education_description { get; set; }
		public string experience { get; set; }
		public string url { get; set; }
		public string skills { get; set; }
		public string birthday { get; set; }
		public string add_date { get; set; }
		public string mod_date { get; set; }
		public bool removal { get; set; }
		public bool is_driver { get; set; }
		public bool is_journey { get; set; }
		public bool is_smoke { get; set; }
		public bool has_child { get; set; }
		public string sex { get; set; }
		public string marital_status { get; set; }
		public bool surname_hide { get; set; }
		public bool can_accept_replies { get; set; }
		public bool hide_birthday { get; set; }
		public string visibility_type { get; set; }
		public EducationDTO education { get; set; }
		public WorkingTypeDTO working_type { get; set; }
		public ScheduleDTO schedule { get; set; }
		public CurrencyDTO currency { get; set; }
		public ExperienceLengthDTO experience_length { get; set; }
		public CitizenshipDTO citizenship { get; set; }
		public List<CitiesReferenceDTO> cities_references { get; set; }
		public List<object> driver_licenses { get; set; }
		public List<object> languages { get; set; }
		public List<object> secondary_educations { get; set; }
		public List<object> institutions { get; set; }
		public List<object> jobs { get; set; }
		public List<RubricDTO> rubrics { get; set; }
		public List<object> recommendations { get; set; }
		public int state { get; set; }
		public int validate_state { get; set; }
		public int entity { get; set; }
		public ContactDTO contact { get; set; }
		public PhotoDTO photo { get; set; }
		public string salary { get; set; }
		public string info_short { get; set; }
		public string info { get; set; }
		public int views { get; set; }
		public object access_status { get; set; }
		public object access_due_date { get; set; }
		public object apiece_count { get; set; }
		public bool is_upped { get; set; }
		public bool is_limit_exceeded { get; set; }
		public bool is_deleted { get; set; }
		public bool is_archived { get; set; }
		public bool legacy { get; set; }
		public int priority { get; set; }
		public object attachment { get; set; }
		public WorkTimeTotalDTO work_time_total { get; set; }
		public List<object> subways { get; set; }
		public List<object> districts { get; set; }
		public List<object> tags { get; set; }
		public string imported_via { get; set; }
		public string url_doc { get; set; }
		public string url_pdf { get; set; }
		public List<int> contact_geo_ids { get; set; }
		public LastLogDTO last_log { get; set; }
		public bool favorite { get; set; }
		public bool hided { get; set; }
	}
}