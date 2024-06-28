namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class ResultProductDtos
    {

       
            public int productId { get; set; }
            public string productTitle { get; set; }
            public decimal productPrice { get; set; }
        public string Description { get; set; }

        public string city { get; set; }
            public string district { get; set; }
            public string categoryName { get; set; }
        public string ProductCoverImage {  get; set; }
        public string Address { get; set; }
            public string Type { get; set; }
        public bool DealOfTheDay { get; set; }
        public DateTime AdvertisementDate { get; set; }
        public string SlugUrl { get; set; }

    }
}
