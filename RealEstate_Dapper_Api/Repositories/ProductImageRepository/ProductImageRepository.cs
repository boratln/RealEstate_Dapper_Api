using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Models.Dtos.ProductImageDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductImageRepository
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly Context _context;
        public ProductImageRepository(Context context) {
        _context = context; 
        }
        public async Task<List<ResultProductImageByProductIdDto>> ProductImageByProductId(int id)
        {
            string query = "Select * from ProductImage where ProductId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection()) {

                var images = await connection.QueryAsync<ResultProductImageByProductIdDto>(query, parameters);
                return images.ToList();
            }
        }
    }
}
