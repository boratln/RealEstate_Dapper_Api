namespace RealEstate_Dapper_Api.Models.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public decimal ProductPrice { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public int ProductCategory { get; set; }

    }
}
