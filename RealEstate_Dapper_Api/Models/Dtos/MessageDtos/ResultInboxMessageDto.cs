namespace RealEstate_Dapper_Api.Models.Dtos.MessageDtos
{
    public class ResultInboxMessageDto
    {
        public int MessageId { get; set; }
        public int Sender { get; set; }
        public int Receiver { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime SendDate { get; set; }
        public string UserImage { get; set; }
        public bool IsRead {  get; set; }
    }
}
