using RealEstate_Dapper_Api.Models.Dtos.AmenityDtos;

namespace RealEstate_Dapper_Api.Repositories.AmenityRepository
{
    public interface IAmenityRepository
    {
        Task<List<ResultAmenityDto>> GetAmenityDtoByStatusTrue(int id);
    }
}
