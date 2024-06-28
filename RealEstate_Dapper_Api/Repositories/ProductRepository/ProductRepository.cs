using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Models.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Models.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository:IProductRepository
    {
        private readonly Context _context;
        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateProduct(CreateProductDtos productDto)
        {
            string query = "insert into product" +
                "(ProductTitle,ProductPrice,ProductCoverImage,City,District,Address," +
                "Description,Type,DealOfTheDay,AdvertisementDate,ProductStatus,UserId,ProductCategory)" +
                "Values (@title,@price,@image,@city,@district,@address,@desc,@type,@dealoftheday,@date,@status,@employee,@category)";
            var parameters = new DynamicParameters();
            parameters.Add("@title", productDto.ProductTitle);
            parameters.Add("@price", productDto.ProductPrice);
            parameters.Add("@image", productDto.ProductCoverImage);
            parameters.Add("@city", productDto.City);
            parameters.Add("@district", productDto.District);
            parameters.Add("@address", productDto.Address);
            parameters.Add("@desc", productDto.Description);
            parameters.Add("@type", productDto.Type);
            parameters.Add("@dealoftheday", productDto.DealOfTheDay);
            parameters.Add("@date", productDto.AdvertisementDate);
            parameters.Add("@status", productDto.ProductStatus);
            parameters.Add("@employee", productDto.EmployeeId);
            parameters.Add("@category", productDto.ProductCategory);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultLast3ProductWithCategoryDto>> GetAllProduct3()
        {
            string query = "select top(3) ProductId,ProductTitle,Description,ProductPrice,City,District,ProductCategory,CategoryName," +
                   "AdvertisementDate,ProductCoverImage from product inner join Category " +
                   "on Product.ProductCategory=Category.CategoryId where Type='Satılık' Order by ProductId desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast3ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetAllProduct5()
        {
            string query = "select top(5) ProductId,ProductTitle,ProductPrice,City,District,ProductCategory,CategoryName," +
                "AdvertisementDate from product inner join Category " +
                "on Product.ProductCategory=Category.CategoryId where Type='Satılık' Order by ProductId desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }
        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeByFalse(int id)
        {
            string query = "SELECT ProductId, ProductTitle, ProductPrice, City, District, " +
               "CategoryName, ProductCoverImage, Type, Address, DealOfTheDay " +
               "FROM PRODUCT " +
               "INNER JOIN Category " +
               "ON PRODUCT.ProductCategory = Category.CategoryId " +
               "WHERE UserId = @id and ProductStatus=0  ";

            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeByTrue(int id)
        {
            string query = "SELECT ProductId, ProductTitle, ProductPrice, City, District, " +
                "CategoryName, ProductCoverImage, Type, Address, DealOfTheDay " +
                "FROM PRODUCT " +
                "INNER JOIN Category " +
                "ON PRODUCT.ProductCategory = Category.CategoryId " +
                "WHERE UserId = @id and ProductStatus=1  ";

            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }

		public async Task<List<ResultProductWithCategory>> GetProductByDealOfTheDayTrueWithCategory()
		{
            string query = "Select * from product where DealOfTheDay=1";
            using(var connection = _context.CreateConnection())
            {
                var values= await connection.QueryAsync<ResultProductWithCategory>(query);
                return values.ToList();
            }
		}

		public async Task<GetProductDetailByProductId> GetProductByProductId(int id)
        {
            string query = "SELECT ProductId,ProductTitle,SlugUrl,ProductPrice,City,District," +
                "CategoryName,ProductCoverImage,Type,Address,DealOfTheDay,AdvertisementDate,Description" +
                " FROM Product " +
                "inner join Category on Product.ProductCategory = Category.CategoryId where ProductId = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetProductDetailByProductId>(query, parameters);
                return value;
            }
        }

        public async Task<GetProductDetailByIdDto> GetProductDetailByProduct(int id)
        {
            string query = "Select * from ProductDetail Where ProductId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryAsync<GetProductDetailByIdDto>(query, parameters);
                return value.FirstOrDefault();
            }
        }

        public async Task<List<ResultProductWithCategory>> GetProductWithCategories()
        {
            string query = "SELECT ProductID,SlugUrl,ProductTitle,ProductPrice,City,District,CategoryName,ProductCoverImage,Type,Address,DealOfTheDay FROM" +
                " Product  inner join Category on Product.ProductCategory=Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategory>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductDto>> GetResultProducts()
        {
            string query = "SELECT * FROM Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task ProductDealOfTheDayStatusChangedToFalse(int id)
        {
            string query = "UPDATE PRODUCT Set DealOfTheDay=0 Where ProductId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query = "UPDATE PRODUCT Set DealOfTheDay=1 Where ProductId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchList(string searchKeyValue, int propertycategoryid, string City)
        {
            string query = "Select * From Product Where ProductTitle like '%" + searchKeyValue + "%' And ProductCategory=@category And City=@city";

            var parameters = new DynamicParameters();
            parameters.Add("@searchkeyvalue", searchKeyValue);
            parameters.Add("@category", propertycategoryid);
            parameters.Add("@city", City);
            using (var connection = _context.CreateConnection()) {
                var values = await connection.QueryAsync<ResultProductWithSearchListDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}
