using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using RealEstate_Dapper_Api.Models.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.Dtos.TestimonialDtos;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepositories
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly Context _context;
        public TestimonialRepository(Context context)
        {
                _context = context;

        }
        public async Task CreateTestimonial(CreateTestimonialDto testimonialDto)
        {
            string query = "insert into Testimonial(Name,Title,Comment,Status) Values(@name,@title,@comment,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", testimonialDto.Name);
            parameters.Add("@title", testimonialDto.Title);
            parameters.Add("@comment", testimonialDto.Comment);
            parameters.Add("@status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteTestimonial(int id)
        {
            string query = "DELETE FROM Testimonial  WHERE TestimonialId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultTestimonialDto>> GetAllTestimonials()
        {
            string query = "SELECT * FROM Testimonial";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTestimonialDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetTestimonialDto> TestimonialDetail(int id)
        {
            string query = "SELECT * FROM Testimonial WHERE TestimoinalId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (var connection = _context.CreateConnection())
            {
                var Testimonial = await connection.QueryFirstOrDefaultAsync<GetTestimonialDto>(query, parameters);
                return Testimonial;
            }
        }

        public async Task UpdateTestimonial(UpdateTestimonialDto testimonialDto)
        {
            string query = "UPDATE Testimonial SET Name=@name, Title=@title,Comment=@comment Status=@status  Where CategoryId=@id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", testimonialDto.TestimonialId);
            parameters.Add("@name", testimonialDto.Name);
            parameters.Add("@comment", testimonialDto.Comment);
            parameters.Add("@status", testimonialDto.Status);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
