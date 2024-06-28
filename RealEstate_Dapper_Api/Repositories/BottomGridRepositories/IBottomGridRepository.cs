using RealEstate_Dapper_Api.Models.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Models.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.Dtos.ServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGrid();
        Task CreateBottomGrid(CreateBottomGridDto bottomgriddto);
        Task DeleteBottomGrid(int id);
        Task UpdateBottomGrid(UpdateBottomGridDto bottomgriddto);
        Task<GetBottomGridDto> BottomGridDetail(int id);
    }
}
