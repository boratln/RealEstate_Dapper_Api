using RealEstate_Dapper_Api.Models.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.LastProductsRepository
{
    public interface ILast5ProductRepository
    {
        Task<List<ResultLast5ProductWithCategoryDto>> GetAllProduct5Async(int id);

    }
}
