using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Models.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.Dtos.EmployeeDtos;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Context _context;
        public EmployeeRepository(Context context)
        {
            _context = context;
        }
        public async Task CreateEmployee(CreateEmployeeDto employeeDto)
        {
            string query = "insert into Employee(EmployeeName,EmployeeTitle,EmployeeMail,EmployeephoneNumber,EmployeeImageUrl,EmployeeStatus) Values(@name,@title,@mail,@phone,@url,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", employeeDto.EmployeeName);
            parameters.Add("@title", employeeDto.EmployeeTitle);
            parameters.Add("@mail", employeeDto.EmployeeMail);
            parameters.Add("@phone", employeeDto.EmployeephoneNumber);
            parameters.Add("@url", employeeDto.EmployeeImageUrl);
            parameters.Add("@status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteEmployee(int id)
        {
            string query = "DELETE FROM Employee  WHERE EmployeeId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<GetByIdEmployeeDto> EmployeeDetail(int id)
        {
            string query = "SELECT * FROM Employee WHERE EmployeeId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (var connection = _context.CreateConnection())
            {
                var employee = await connection.QueryFirstOrDefaultAsync<GetByIdEmployeeDto>(query, parameters);
                return employee;
            }
        }

        public async Task<List<ResultEmployeeDto>> GetAllEmployee()
        {
            string query = "SELECT * FROM Employee";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultEmployeeDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateEmployee(UpdateEmployeeDto employeeDto)
        {
            string query = "UPDATE Employee SET EmployeeName=@name,EmployeeTitle=@title,EmployeeMail=@mail,EmployeephoneNumber=@phone,EmployeeImageUrl=@url, EmployeeStatus=@status  Where EmployeeId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", employeeDto.EmployeeId);
            parameters.Add("@name", employeeDto.EmployeeName);
            parameters.Add("@title", employeeDto.EmployeeTitle);
            parameters.Add("@mail", employeeDto.EmployeeMail);
            parameters.Add("@phone", employeeDto.EmployeephoneNumber);
            parameters.Add("@url", employeeDto.EmployeeImageUrl);
            parameters.Add("@status", employeeDto.EmployeeStatus);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
