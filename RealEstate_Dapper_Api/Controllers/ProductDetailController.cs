using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductDetailController(IProductRepository productRepository) {
        this.productRepository = productRepository;
        }
        [HttpGet("GetProductDetailByProduct/{id}")]
        public async Task<IActionResult> GetProductDetailByProduct(int id)
        {
            var value = await productRepository.GetProductDetailByProduct(id);
            return Ok(value);
        }
    }
}
