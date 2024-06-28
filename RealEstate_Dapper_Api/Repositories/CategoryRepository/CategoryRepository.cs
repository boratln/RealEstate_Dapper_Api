using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Models.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;
        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async Task<GetByCategoryDto> CategoryDetail(int id)
        {
            string query = "SELECT * FROM Category WHERE CategoryId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (var connection = _context.CreateConnection())
            {
                var category = await connection.QueryFirstOrDefaultAsync<GetByCategoryDto>(query, parameters);
                return category;
            }
        }


        public async Task CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "insert into Category(CategoryName,CategoryStatus) Values(@name,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", categoryDto.CategoryName);
            parameters.Add("@status",true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCategory(int id)
        {
            string query = "DELETE FROM Category  WHERE CategoryId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategory()
        {
            string query = "SELECT * FROM Category";
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateCategory(UpdateCategoryDto categoryDto)
        {
            string query = "UPDATE Category SET CategoryName=@name, CategoryStatus=@status  Where CategoryId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", categoryDto.CategoryId);
            parameters.Add("@name", categoryDto.CategoryName);
            parameters.Add("@status", categoryDto.CategoryStatus);
            using(var connection= _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
