using Microsoft.Data.SqlClient;
using System.Data;

namespace RealEstate_Dapper_Api.Models.DapperContext
{
    public class Context
    {
        //Dapper yoluyla Db Bağlantısı
        private readonly IConfiguration _configuration;
        private readonly string _connectionstring;

        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionstring = _configuration.GetConnectionString("Connectionstring");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionstring);
    }
}
