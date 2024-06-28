namespace RealEstate_Dapper_Api.Models.Dtos.CategoryDtos
{
    public class GetByCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
    }
}
