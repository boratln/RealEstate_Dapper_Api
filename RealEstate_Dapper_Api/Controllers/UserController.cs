using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.UserRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userrepository;
        public UserController(IUserRepository userrepository)
        {
            _userrepository = userrepository;
        }
        [HttpGet("GetUserByProductId/{id}")]
        public async Task<IActionResult> GetUserByProductId(int id)
        {
            var value= await _userrepository.GetUserByProductId(id);
            return Ok(value);

        }
    }
}
