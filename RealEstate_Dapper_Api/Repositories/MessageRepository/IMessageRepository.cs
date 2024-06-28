using RealEstate_Dapper_Api.Models.Dtos.MessageDtos;
namespace RealEstate_Dapper_Api.Repositories.MessageRepository
{
    public interface IMessageRepository
    {
        Task<List<ResultInboxMessageDto>> GetInboxLast3MessageListByReceiver(int id);
    }
}
