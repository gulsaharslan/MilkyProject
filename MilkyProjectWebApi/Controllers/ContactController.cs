using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
           _contactService = contactService;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(Contact contact)
        {
            contact.Date = DateTime.Now;
            _contactService.TInsert(contact);
            return Ok("Başarıyla Eklendi");
        }
        [HttpDelete]

        public IActionResult DeleteContact(int id)
        {
            _contactService.TDelete(id);
            return Ok("Başarıyla silindi");
        }
        [HttpGet("GetContact")]

        public IActionResult GetContact(int id)
        {
            var value = _contactService.TGetById(id);
            return Ok(value);
        }
    }
}
