using RealEstate_Dapper_Api.Models.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.Dtos.EmployeeDtos;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepository
{
    public interface IEmployeeRepository
    {
        Task<List<ResultEmployeeDto>> GetAllEmployee();
        Task CreateEmployee(CreateEmployeeDto categoryDto);
        Task DeleteEmployee(int id);
        Task UpdateEmployee(UpdateEmployeeDto categoryDto);
        Task<GetByIdEmployeeDto> EmployeeDetail(int id);
    }
}
