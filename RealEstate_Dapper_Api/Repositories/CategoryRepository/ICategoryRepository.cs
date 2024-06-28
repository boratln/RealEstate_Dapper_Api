using RealEstate_Dapper_Api.Models.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategory();
        Task CreateCategory(CreateCategoryDto categoryDto);
        Task DeleteCategory(int id);
        Task UpdateCategory(UpdateCategoryDto categoryDto);
        Task<GetByCategoryDto> CategoryDetail(int id);
    }
    
}
