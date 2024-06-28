using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Models.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.Dtos.ServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly Context _context;
        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public async Task<GetByServiceDto> ServiceDetail(int id)
        {
            string query = "SELECT * FROM Service WHERE ServiceId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (var connection = _context.CreateConnection())
            {
                var category = await connection.QueryFirstOrDefaultAsync<GetByServiceDto>(query, parameters);
                return category;
            }
        }

        public async Task CreateService(CreateServiceDto serviceDto)
        {
            string query = "insert into Service(ServiceName,ServiceStatus) Values(@name,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", serviceDto.ServiceName);
            parameters.Add("@status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteService(int id)
        {
            string query = "DELETE FROM Service  WHERE ServiceId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultServiceDto>> GetAllServices()
        {
            string query = "SELECT * FROM Service";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultServiceDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateService(UpdateServiceDto serviceDto)
        {
            string query = "UPDATE Service SET ServiceName=@name, ServiceStatus=@status  Where ServiceId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", serviceDto.ServiceId);
            parameters.Add("@name", serviceDto.ServiceName);
            parameters.Add("@status", serviceDto.ServiceStatus);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
