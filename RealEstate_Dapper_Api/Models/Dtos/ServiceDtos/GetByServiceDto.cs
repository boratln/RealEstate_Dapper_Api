namespace RealEstate_Dapper_Api.Models.Dtos.ServiceDtos
{
    public class GetByServiceDto
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public bool ServiceStatus { get; set; }
    }
}
