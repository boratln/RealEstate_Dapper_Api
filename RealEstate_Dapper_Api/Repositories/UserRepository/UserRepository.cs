using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Models.Dtos.UserDtos;

namespace RealEstate_Dapper_Api.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context) { 
        _context= context;
        }
        public async Task<GetUserByProductIdDto> GetUserByProductId(int id)
        {
            string query = "select  Users.UserId, Name, Email, PhoneNumber, UserImage from Product inner join Users on Users.UserId = Product.UserId where ProductId = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

           
                using (var connection = _context.CreateConnection())
                {
                    var value = await connection.QueryFirstOrDefaultAsync<GetUserByProductIdDto>(query, parameters);
                    return value;
                }
            
         
        }

    }
}
