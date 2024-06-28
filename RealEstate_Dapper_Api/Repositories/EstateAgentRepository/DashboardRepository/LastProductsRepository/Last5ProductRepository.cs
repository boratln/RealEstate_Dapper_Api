using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Models.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.LastProductsRepository
{
    public class Last5ProductRepository : ILast5ProductRepository
    {
        private readonly Context _context;
        public Last5ProductRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultLast5ProductWithCategoryDto>> GetAllProduct5Async(int id)
        {
            
            using (var connection = _context.CreateConnection())
            {
                string query = "select top(5) ProductId,ProductTitle,ProductPrice,City,District,ProductCategory,CategoryName," +
             "AdvertisementDate from product inner join Category " +
             "on Product.ProductCategory=Category.CategoryId where Type='Satılık' and UserId=@id Order by ProductId desc";
                var parameters = new DynamicParameters();
                parameters.Add("@id", id);
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query,parameters);
                return values.ToList();
            }
        }
    }
}
