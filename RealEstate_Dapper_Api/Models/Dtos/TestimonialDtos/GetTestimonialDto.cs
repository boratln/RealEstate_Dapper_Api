namespace RealEstate_Dapper_Api.Models.Dtos.TestimonialDtos
{
    public class GetTestimonialDto
    {
        public int TestimonialId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }
    }
}
