using System.Collections.Generic;
using AdvertExplorer.Server.Domain.Entities;
using AdvertExplorer.Server.Domain.Services;
using AdvertExplorer.Server.Domain.ValueObjects;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AdvertExplorer.Server.Web.Controllers
{
	[EnableCors("FullAccess")]
	[Route("api/[controller]")]
	public class ResumesController : Controller
	{
		private readonly IResumeService _resumeService;

		public ResumesController(IResumeService resumeService)
		{
			_resumeService = resumeService;
		}

		// GET api/resumes?region=0&rubric=0&experience=0&salary=0&maxAge=0&minAge=0&searchString='foo'
		[HttpGet]
		public IReadOnlyCollection<Resume> Get(
			[FromQuery] Region region,
			[FromQuery] Rubric? rubric,
			[FromQuery] Experience? experience,
			[FromQuery] uint? salary,
			[FromQuery] uint? maxAge,
			[FromQuery] uint? minAge,
			[FromQuery] string searchString)
			=> _resumeService.GetBy(region, rubric, experience, salary, maxAge, minAge, searchString);
	}
}