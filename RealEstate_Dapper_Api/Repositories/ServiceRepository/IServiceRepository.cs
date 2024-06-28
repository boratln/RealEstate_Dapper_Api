using RealEstate_Dapper_Api.Models.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.Dtos.ServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServices();
        Task CreateService(CreateServiceDto serviceDto);
        Task DeleteService(int id);
        Task UpdateService(UpdateServiceDto serviceDto);
        Task<GetByServiceDto> ServiceDetail(int id);
    }
}
