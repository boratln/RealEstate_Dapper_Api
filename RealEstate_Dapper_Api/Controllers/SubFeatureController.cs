using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.SubFeatureRepository;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SubFeatureController : ControllerBase
	{
		private readonly ISubFeatureRepository _subFeatureRepository;
		public SubFeatureController(ISubFeatureRepository subFeatureRepository)
		{
			_subFeatureRepository = subFeatureRepository;
		}
		[HttpGet]
		public async Task<IActionResult> GetAllSubFeatureDto()
		{
			var values = await _subFeatureRepository.GetAllSubFeatureDto();
			return Ok(values);
		}
	}
}
