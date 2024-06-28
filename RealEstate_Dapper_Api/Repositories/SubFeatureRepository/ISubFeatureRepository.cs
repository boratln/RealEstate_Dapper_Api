using RealEstate_Dapper_Api.Models.Dtos.SubFeatureDtos;

namespace RealEstate_Dapper_Api.Repositories.SubFeatureRepository
{
	public interface ISubFeatureRepository
	{
		Task<List<ResultSubFeatureDto>> GetAllSubFeatureDto();
	}
}
