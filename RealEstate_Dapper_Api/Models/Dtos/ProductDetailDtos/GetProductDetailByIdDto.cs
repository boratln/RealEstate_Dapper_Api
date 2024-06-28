﻿namespace RealEstate_Dapper_Api.Models.Dtos.ProductDetailDtos
{
    public class GetProductDetailByIdDto
    {
        public int ProductDetailId { get; set; }
        public int ProductSize { get; set; }
        public int BathRoomCount { get; set; }
        public int BedRoomCount { get; set; }
        public int RoomCount { get; set; }
        public int GarageSize { get; set; }
        public int BuildYear { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string videourl { get; set; }
        public int ProductId { get; set; }
    }
}
