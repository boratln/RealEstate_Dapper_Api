using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Models.Dtos.SubFeatureDtos;

namespace RealEstate_Dapper_Api.Repositories.SubFeatureRepository
{
	public class SubFeatureRepository : ISubFeatureRepository
	{
		private readonly Context _context;
		public SubFeatureRepository(Context context) {
		_context = context;
		}
		public async Task<List<ResultSubFeatureDto>> GetAllSubFeatureDto()
		{
			string query = "Select * from SubFeature";
			using (var connection = _context.CreateConnection()) { 
			var values= await connection.QueryAsync<ResultSubFeatureDto>(query);
				return values.ToList();
			}
		}
	}
}
