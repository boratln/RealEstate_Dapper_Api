using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.MessageRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;
        public MessageController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        [HttpGet("Get3MessageListbyreceiver/{id}")]
        public async  Task<IActionResult> Get3MessageListbyreceiver(int id)
        {
            var values = await _messageRepository.GetInboxLast3MessageListByReceiver(id);
            return Ok(values);
        }
    }
}
