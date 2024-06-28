using RealEstate_Dapper_Api.Models.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Models.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetResultProducts();
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeByTrue(int id);
        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeByFalse(int id);
        Task<List<ResultProductWithCategory>> GetProductWithCategories();
        Task ProductDealOfTheDayStatusChangeToTrue(int id);
        Task ProductDealOfTheDayStatusChangedToFalse(int id);
        Task<List<ResultLast5ProductWithCategoryDto>> GetAllProduct5();
        Task<List<ResultLast3ProductWithCategoryDto>> GetAllProduct3();

        Task CreateProduct(CreateProductDtos productDto);
        Task<GetProductDetailByProductId> GetProductByProductId(int id);
        Task<GetProductDetailByIdDto> GetProductDetailByProduct(int id);
        Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchList(string searchKeyValue, int propertycategoryid, string City);
        Task<List<ResultProductWithCategory>> GetProductByDealOfTheDayTrueWithCategory();
    }
}
