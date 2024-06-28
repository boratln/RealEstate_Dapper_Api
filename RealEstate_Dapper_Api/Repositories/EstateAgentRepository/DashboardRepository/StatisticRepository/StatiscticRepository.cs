using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepository.DashboardRepository.StatisticRepository
{
    public class StatiscticRepository : IStatisticRepository
    {
        private readonly Context _context;
        public StatiscticRepository(Context context) {
        _context = context;
        }
        public int AllProductCount()
        {
            using (var connection = _context.CreateConnection()) {

                string query = "Select Count(*) from product";
                var value=connection.QueryFirstOrDefault<int>(query);
                return value;
            }
        }

        public int ProductCountByEmployeeId(int id)
        {
            using (var connection = _context.CreateConnection()) {
                string query = "Select Count(*) from product where UserId=@id";
                var parameteres = new DynamicParameters();
                parameteres.Add("@id", id);

                var value= connection.QueryFirstOrDefault<int>(query,parameteres);
                return value;
            
            }
        }

        public int ProductCountByStatusFalse(int id)
        {
            using (var connection = _context.CreateConnection()) {
                string query = "Select count(*) from product where UserId=@id and ProductStatus=0";
                var parameteres = new DynamicParameters();
                parameteres.Add("@id", id);
                var value = connection.QueryFirstOrDefault<int>(query,parameteres);
                return value;
            }
        }

        public int ProductCountByStatusTrue(int id)
        {
            using (var connection = _context.CreateConnection())
            {
                string query = "Select count(*) from product where UserId=@id and ProductStatus=1";
                var parameteres = new DynamicParameters();
                parameteres.Add("@id", id);
                var value = connection.QueryFirstOrDefault<int>(query, parameteres);
                return value;
            }
        }
    }
}
