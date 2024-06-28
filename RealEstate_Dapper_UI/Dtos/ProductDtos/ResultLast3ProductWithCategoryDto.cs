namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class ResultLast3ProductWithCategoryDto
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public decimal ProductPrice { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public int ProductCategory { get; set; }
        public string CategoryName { get; set; }
        public string ProductCoverImage { get; set; }
        public string Description { get; set; }
        public DateTime AdvertisementDate { get; set; }
    }
}
