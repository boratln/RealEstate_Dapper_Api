using RealEstate_Dapper_Api.Models.Dtos.ContactDtos;

namespace RealEstate_Dapper_Api.Repositories.ContactRepository
{
    public interface IContactRepository
    {
        Task<List<ResultContactDto>> GetAllContact();
        Task<List<ResultLast4ContactDto>> GetAllLast4Contact();
        Task CreateContact(CreateContactDto contactDto);
        Task DeleteContact(int id);
        Task<GetByIdContactDto> ContactDetail(int id);
    }
}
