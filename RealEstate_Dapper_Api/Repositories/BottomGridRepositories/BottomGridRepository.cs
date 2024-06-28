using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Models.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Models.Dtos.ServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly Context _context;
        public BottomGridRepository(Context context)
        {
            _context = context;
        }
        public async Task<GetBottomGridDto> BottomGridDetail(int id)
        {
            string query = "SELECT * FROM BottomGrid WHERE BottomGridId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (var connection = _context.CreateConnection())
            {
                var bottomgrid = await connection.QueryFirstOrDefaultAsync<GetBottomGridDto>(query, parameters);
                return bottomgrid;
            }
        }

        public async Task CreateBottomGrid(CreateBottomGridDto bottomgriddto)
        {
            string query = "insert into BottomGrid(Icon,Title,Description) Values(@icon,@title,@desc)";
            var parameters = new DynamicParameters();
            parameters.Add("@title",bottomgriddto.Title);
            parameters.Add("@icon", bottomgriddto.Icon);
            parameters.Add("@desc", bottomgriddto.Description);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteBottomGrid(int id)
        {
            string query = "DELETE FROM BottomGrid  WHERE BottomGridId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGrid()
        {
            string query = "SELECT * FROM BottomGrid";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultBottomGridDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateBottomGrid(UpdateBottomGridDto bottomgriddto)
        {
            string query = "UPDATE BottomGrid SET Icon=@icon, Title=@title, Description=@desc  Where ServiceId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", bottomgriddto.BottomGridId);
            parameters.Add("@title", bottomgriddto.Title);
            parameters.Add("@desc", bottomgriddto.Description);
            parameters.Add("@icon", bottomgriddto.Icon);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
