namespace RealEstate_Dapper_Api.Models.Dtos.PopularLocationDtos
{
    public class ResultPopularLocationDto
    {
        public int LocationId { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public int PropertyCount { get; set; }
    }
}
