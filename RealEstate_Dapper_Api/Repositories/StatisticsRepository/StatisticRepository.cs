using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Models.Dtos.EmployeeDtos;
using System.Text.RegularExpressions;

namespace RealEstate_Dapper_Api.Repositories.StatisticsRepository
{
    public class StatisticRepository : IstatisticsRepository
    {

        private readonly Context _context;
        public StatisticRepository(Context context)
        {
            _context = context;
        }
        public int ActiveCategoryCount()
        {
            string query = "SELECT COUNT(*) FROM Category Where CategoryStatus=1";
            using (var connection = _context.CreateConnection())
            {
                var values =  connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ActiveEmployeeCount()
        {
            string query = "SELECT COUNT(*) FROM Employee Where EmployeeStatus=1";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ApartmentCount()
        {
            string query = "select COUNT(*) from Product where ProductTitle like '%Daire%'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public decimal AverageProductPriceByRent()
        {
            string query = "select AVG(ProductPrice) from Product where Type like '%Kiralık%'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public decimal AverageProductPriceBySale()
        {
            string query = "select AVG(ProductPrice) from Product where Type like '%Satılık%'";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int AvereageRoomCount()
        {
            string query = "Select AVG(RoomCount) from ProductDetail";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public  int CategoryCount()
        {
            string query = "SELECT COUNT(*) FROM Category";
            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string CategoryNameByMaxProductCount()
        {
            string query = @"
    SELECT TOP (1) Category.CategoryName
    FROM Product
    INNER JOIN Category ON Product.ProductCategory = Category.CategoryId
    GROUP BY Category.CategoryName
    ORDER BY COUNT(*) DESC";

            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public string CityNameByMaxProductCount()
        {
            string query = @"
   Select top(1) Product.City from 
Product
inner join Category on Product.ProductCategory=Category.CategoryId
GROUP BY Product.City ORDER BY COUNT(*) desc";

            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public int DifferentCityCount()
        {
            string query = "SELECT COUNT(DISTINCT City) FROM product";

            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public string EmployeeNameByMaxProductCount()
        {
            string query = "select EmployeeName,Count(*) 'product_count' From Product " +
                "Inner Join Employee On Product.UserId = Employee.EmployeeId " +
                "Group By EmployeeName Order By product_count Desc";

            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public decimal LastProductPrice()
        {
            string query = "SELECT TOP (1) ProductPrice FROM product ORDER BY ProductId DESC;";

            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<decimal>(query);
                return values;
            }
        }

        public string NewestBuildingYear()
        {
            string query = "Select top(1) BuildYear from ProductDetail order by BuildYear desc";

            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public string OldestBuildingYear()
        {
            string query = "Select top(1) BuildYear from ProductDetail order by BuildYear ";

            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<string>(query);
                return values;
            }
        }

        public int PassiveCategoryCount()
        {
            string query = "Select COUNT(*) from Category where CategoryStatus=0";

            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }

        public int ProductCount()
        {
            string query = "Select COUNT(*) from Product";

            using (var connection = _context.CreateConnection())
            {
                var values = connection.QueryFirstOrDefault<int>(query);
                return values;
            }
        }
    }
}
