using RealEstate_Dapper_Api.Models.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.Dtos.TestimonialDtos;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepositories
{
    public interface ITestimonialRepository
    {
        Task<List<ResultTestimonialDto>> GetAllTestimonials();
        Task CreateTestimonial(CreateTestimonialDto testimonialDto);
        Task DeleteTestimonial(int id);
        Task UpdateTestimonial(UpdateTestimonialDto testimonialDto);
        Task<GetTestimonialDto> TestimonialDetail(int id);
    }
}
