using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Models.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        [HttpGet("GetAllProduct5Async")]
        public async Task <IActionResult> GetAllProduct5Async()
        {
            var list = await productRepository.GetAllProduct5();
            return Ok(list);
        }
        [HttpGet]
        public async Task <IActionResult> Get()
        {
           var values= await productRepository.GetResultProducts();
            return Ok(values);
        }

        [HttpGet("ProductListWithCategory")]
        public async Task  <IActionResult> ProductList()
        {
            var values = await productRepository.GetProductWithCategories();
            return Ok(values);
        }
        [HttpGet("DealOfTheDayStatusChangeToTrue/{id}")]
        public async Task<IActionResult> DealOfTheDayStatusChangeToTrue(int id)
        {
            await productRepository.ProductDealOfTheDayStatusChangeToTrue(id);
            return Ok("Günün ilanı oldu");
        }
        [HttpGet("DealOfTheDayStatusChangeToFalse/{id}")]
        public async Task<IActionResult> DealOfTheDayStatusChangeToFalse(int id)
        {
            await productRepository.ProductDealOfTheDayStatusChangedToFalse(id);
            return Ok("Günün ilanı çıkarıldı");
        }

        [HttpGet("ProductAdvertsListByEmployeeIdByTrue/{id}")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeIdByTrue(int id)
        {
            var list=await productRepository.GetProductAdvertListByEmployeeByTrue(id);
            return Ok(list);
        }
        [HttpGet("ProductAdvertsListByEmployeeIdByFalse/{id}")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeIdByFalse(int id)
        {
            var list = await productRepository.GetProductAdvertListByEmployeeByFalse(id);
            return Ok(list);
        }
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDtos productdto)
        {
            await productRepository.CreateProduct(productdto);
            return Ok("İlan başarıyla eklendi");
        }
        [HttpGet("GetProductByProductId/{id}")]
        public async Task<IActionResult> GetProductByProductId(int id)
        {
            var value = await productRepository.GetProductByProductId(id);
            return Ok(value);
        }
        [HttpGet("ResultProductWithSearchList")]
        public async Task<IActionResult> ResultProductWithSearchList(string keyword,int categoryid,string city)
        {
            var value=await productRepository.ResultProductWithSearchList(keyword,categoryid,city);
            return Ok(value);
        }

        [HttpGet("GetProductByDealOfTheDayTrueWithCategory")]
        public async  Task<IActionResult> GetProductByDealOfTheDayTrueWithCategory()
        {
            var value = await productRepository.GetProductByDealOfTheDayTrueWithCategory();
            return Ok(value);

		}
        [HttpGet("GetAllProduct3Async")]
        public async Task<IActionResult> GetAllProduct3Async()
        {
           var value=await productRepository.GetAllProduct3();
            return Ok(value);
        }



    }
}
