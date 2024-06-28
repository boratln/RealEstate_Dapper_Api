using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Models.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Models.Dtos.EmployeeDtos;

namespace RealEstate_Dapper_Api.Repositories.ContactRepository
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;
        public ContactRepository(Context context)
        {
            _context = context;
        }
        public async Task<GetByIdContactDto> ContactDetail(int id)
        {
            string query = "SELECT * FROM Contact WHERE ContactId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (var connection = _context.CreateConnection())
            {
                var contact = await connection.QueryFirstOrDefaultAsync<GetByIdContactDto>(query, parameters);
                return contact;
            }
        }

        public async Task CreateContact(CreateContactDto contactDto)
        {
            string query = "INSERT INTO Contact(Name,Subject,Email,Message,SendDate) VALUES(@name,@subject,@email,@message,@senddate)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", contactDto.Name);
            parameters.Add("@subject", contactDto.Subject);
            parameters.Add("@email", contactDto.Email);
            parameters.Add("@message", contactDto.Message);
            parameters.Add("@senddate", contactDto.SendDate);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteContact(int id)
        {
            string query = "Delete From Contact Where ContactId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection()) {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultContactDto>> GetAllContact()
        {
            string query = "SELECT * FROM Contact";
            using (var connection = _context.CreateConnection())
            {
            var list=await connection.QueryAsync<ResultContactDto>(query);
                return list.ToList();
            }
        }

        public async Task<List<ResultLast4ContactDto>> GetAllLast4Contact()
        {
            string query = "SELECT Top(4) * FROM Contact order by ContactId Desc";
            using (var connection = _context.CreateConnection())
            {
                var list = await connection.QueryAsync<ResultLast4ContactDto>(query);
                return list.ToList();
            }
        }
    }
}
