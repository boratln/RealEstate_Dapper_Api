using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Models.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Models.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public class PopularLocationRepository : IPopularLocationRepository
    {
        private readonly Context _context;
        public PopularLocationRepository(Context context)
        {
            _context = context;
        }
        public async Task CreatePopularLocation(CreatePopularLocationDto popularLocationDto)
        {
            string query = "insert into PopularLocation(City,ImageUrl) Values(@city,@url)";
            var parameters = new DynamicParameters();
            parameters.Add("@city", popularLocationDto.City);
            parameters.Add("@url", popularLocationDto.ImageUrl);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeletePopularLocation(int id)
        {
            string query = "DELETE FROM PopularLocation  WHERE LocationId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultPopularLocationDto>> GetAllPopularLocation()
        {
            string query = "SELECT * FROM PopularLocation";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPopularLocationDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetPopularLocationDto> PopularLocationDetail(int id)
        {
            string query = "SELECT * FROM PopularLocation WHERE LocationId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (var connection = _context.CreateConnection())
            {
                var PopularLocation = await connection.QueryFirstOrDefaultAsync<GetPopularLocationDto>(query, parameters);
                return PopularLocation;
            }
        }

        public async Task UpdatePopularLocation(UpdatePopularLocationDto popularLocationDto)
        {
            string query = "UPDATE PopularLocation SET City=@city, ImageUrl=@url,  Where LocationId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", popularLocationDto.LocationId);
            parameters.Add("@city", popularLocationDto.City);
            parameters.Add("@url", popularLocationDto.ImageUrl);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
