using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductImageRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IProductImageRepository _productImageRepository;
        public ProductImageController(IProductImageRepository productImageRepository)
        {
            _productImageRepository= productImageRepository;
        }
        [HttpGet("GetProductImageByProductId/{id}")]
        public async Task<IActionResult> GetProductImageByProductId(int id)
        {
            var value = await _productImageRepository.ProductImageByProductId(id);
            return Ok(value);
        }

    }
}
