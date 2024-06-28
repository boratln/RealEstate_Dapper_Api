using RealEstate_Dapper_Api.Models.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Models.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
    public interface IPopularLocationRepository
    {
        Task<List<ResultPopularLocationDto>> GetAllPopularLocation();
        Task CreatePopularLocation(CreatePopularLocationDto popularLocationDto);
        Task DeletePopularLocation(int id);
        Task UpdatePopularLocation(UpdatePopularLocationDto popularLocationDto);
        Task<GetPopularLocationDto> PopularLocationDetail(int id);
    }
}
