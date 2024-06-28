using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Models.Dtos.AmenityDtos;

namespace RealEstate_Dapper_Api.Repositories.AmenityRepository
{
    public class AmenityRepository : IAmenityRepository
    {
        private readonly Context _context;
        public AmenityRepository(Context context) { 
        _context = context;
        }
        public async Task<List<ResultAmenityDto>> GetAmenityDtoByStatusTrue(int id)
        {
            string query = "select * from Amenity " +
                 "inner join PropertyAmenity on PropertyAmenity.AmenityId=Amenity.AmenityId " +
                 "where Status=1 and PropertyId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values= await connection.QueryAsync<ResultAmenityDto>(query,parameters);
                return values.ToList();
            }
        }
    }
}
