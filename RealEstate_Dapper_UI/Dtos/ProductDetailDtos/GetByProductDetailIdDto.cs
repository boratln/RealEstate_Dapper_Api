namespace RealEstate_Dapper_UI.Dtos.ProductDetailDtos
{
    public class GetByProductDetailIdDto
    {

		public int ProductDetailId { get; set; }
		public int BedRoomCount { get; set; }
		public int ProductSize { get; set; }
		public int BathRoomCount { get; set; }
		public int RoomCount { get; set; }
		public int GarageSize { get; set; }
		public string BuildYear { get; set; }
		public decimal Price { get; set; }
		public string Location { get; set; }
		public string Videourl { get; set; }
		public int productId { get; set; }
		public DateTime AdvertisementDate { get; set; }


	}
}
