namespace RealEstate_Dapper_Api.Models.Dtos.ProductDtos
{
    public class ResultProductWithCategory
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string SlugUrl { get; set; }
        public decimal ProductPrice { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string CategoryName { get; set; }
        public string ProductCoverImage { get; set; }
        public string Type {  get; set; }
        public string Address { get; set; }
        public bool DealOfTheDay { get; set; }



    }
}
