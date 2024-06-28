using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Models.Dtos.MessageDtos;

namespace RealEstate_Dapper_Api.Repositories.MessageRepository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;
        public MessageRepository(Context context) {
        
        _context= context;
        }
        public async Task<List<ResultInboxMessageDto>> GetInboxLast3MessageListByReceiver(int id)
        {
            string query = "SELECT TOP(3) " +
                "    u1.Name AS [SenderName], " +
                "  Subject AS Subject,  " +
                "   Detail AS [Content],  " +
                "   SendDate AS [SendDate], " +
                " u1.UserImage " +
                "FROM Message " +
                "INNER JOIN Users u1 ON u1.UserId = Message.Sender " +
                "WHERE Receiver = @id ORDER BY SendDate DESC;";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection()) {
            var values= await connection.QueryAsync<ResultInboxMessageDto>(query, parameters);
                return values.ToList();
            
            }
        }
    }
}
