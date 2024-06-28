namespace RealEstate_Dapper_Api.Models.Dtos.UserDtos
{
    public class GetUserByProductIdDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string UserImage { get; set; }

    }
}
