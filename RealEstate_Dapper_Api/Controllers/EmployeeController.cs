using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Models.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.EmployeeRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var values = await employeeRepository.GetAllEmployee();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> Post( CreateEmployeeDto employeeDto)
        {
            await employeeRepository.CreateEmployee(employeeDto);
            return Ok("Kategori başarıyla eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await employeeRepository.DeleteEmployee(id);
            return Ok("Başarıyla silindi");
        }
        [HttpPut]
        public IActionResult Put(UpdateEmployeeDto employeeDto)
        {
            employeeRepository.UpdateEmployee(employeeDto);
            return Ok("Başarıyla güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await employeeRepository.EmployeeDetail(id);
            return Ok(employee);
        }
    }
}
