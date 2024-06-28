using RealEstate_Dapper_Api.Models.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.Dtos.WhoWeAreDtos;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public interface IWhoWeAreRepository
    {
        Task<List<ResultWhoWeAreDtos>> GetResultWhoWeAreDetail();
        Task CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto);
        Task DeleteWhoWeAreDetail(int id);
        Task UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto);
        Task<GetByIdWhoWeAreDetailDto> WhoWeAreDetail(int id);
    }
}
