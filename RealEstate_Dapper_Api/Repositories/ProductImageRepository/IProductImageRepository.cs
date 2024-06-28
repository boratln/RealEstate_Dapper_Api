using RealEstate_Dapper_Api.Models.Dtos.ProductImageDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductImageRepository
{
    public interface IProductImageRepository
    {
        Task<List<ResultProductImageByProductIdDto>> ProductImageByProductId(int id);
    }
}
