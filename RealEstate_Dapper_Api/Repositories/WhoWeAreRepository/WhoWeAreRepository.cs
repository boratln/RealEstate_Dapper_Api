using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Models.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.Dtos.WhoWeAreDtos;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public class WhoWeAreRepository : IWhoWeAreRepository
    {
        private readonly Context _context;
        public WhoWeAreRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetail)
        {
            string query = "insert into WhoWeAreDetail(Title,Subtitle,Description1,Description2)" +
                " Values(@title,@subtitle,@desc1,@desc2)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", createWhoWeAreDetail.Title);
            parameters.Add("@subtitle", createWhoWeAreDetail.SubTitle);
            parameters.Add("@desc1", createWhoWeAreDetail.Description1);
            parameters.Add("@desc2", createWhoWeAreDetail.Description2);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteWhoWeAreDetail(int id)
        {
            string query = "DELETE FROM WhoWeAreDetail  WHERE WhoWeAreDetailId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultWhoWeAreDtos>> GetResultWhoWeAreDetail()
        {
            string query = "SELECT * FROM WhoWeAreDetail";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultWhoWeAreDtos>(query);
                return values.ToList();
            }
        }

     

        public async Task UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            string query = "UPDATE WhoWeAreDetail SET Title=@title, Subtitle=@subtitle,Description1=@desc1," +
                "Description2=@desc2" +
                "  Where WhoWeAreDetailId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", updateWhoWeAreDetailDto.WhoWeAreDetailId);
            parameters.Add("@title", updateWhoWeAreDetailDto.Title);
            parameters.Add("@subtitle", updateWhoWeAreDetailDto.SubTitle);
            parameters.Add("@desc1", updateWhoWeAreDetailDto.Description1);
            parameters.Add("@desc2", updateWhoWeAreDetailDto.Description2);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetByIdWhoWeAreDetailDto> WhoWeAreDetail(int id)
        {
            string query = "SELECT * FROM WhoWeAreDetail WHERE UpdateWhoWeAreDetailId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (var connection = _context.CreateConnection())
            {
                var whoWeAreDetail = await connection.QueryFirstOrDefaultAsync<GetByIdWhoWeAreDetailDto>(query, parameters);
                return whoWeAreDetail;
            }
        }
    }
}
