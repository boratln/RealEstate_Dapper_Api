using RealEstate_Dapper_Api.Models.Dtos.UserDtos;

namespace RealEstate_Dapper_Api.Repositories.UserRepository
{
    public interface IUserRepository
    {
        Task<GetUserByProductIdDto> GetUserByProductId(int id);
    }
}
