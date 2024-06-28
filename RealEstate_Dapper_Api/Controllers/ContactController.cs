using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Models.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Repositories.ContactRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }
        [HttpGet]
        public async Task <IActionResult> Get()
        {
            var list = await contactRepository.GetAllContact();
            return Ok(list);
        }
        [HttpPost]
        public IActionResult Post(CreateContactDto contactdto)
        {
            contactRepository.CreateContact(contactdto);
            return Ok("Başarıyla eklendi");

        }
        [HttpGet("Last4Contact")]
        public async Task<IActionResult> Last4Contact()
        {
            var list = await contactRepository.GetAllLast4Contact();
            return Ok(list);
        }
        [HttpPut]
        public IActionResult Delete(int id)
        {
            contactRepository.DeleteContact(id);
            return Ok("Başarıyla silindi");
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var contact = contactRepository.ContactDetail(id);
            return Ok(contact);
        }
    }
}
