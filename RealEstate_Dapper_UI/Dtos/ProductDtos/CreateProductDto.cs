﻿namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductTitle { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCoverImage { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool DealOfTheDay { get; set; }
        public DateTime AdvertisementDate { get; set; }
        public bool ProductStatus { get; set; }
        public int EmployeeId { get; set; }
        public int ProductCategory { get; set; }
    }
}
