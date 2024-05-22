using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactDetailController : ControllerBase
    {
        private readonly IContactDetailService _contactDetailService;

        public ContactDetailController(IContactDetailService contactDetailService)
        {
            _contactDetailService = contactDetailService;
        }
        [HttpGet]
        public IActionResult ContactDetailList()
        {
           var values= _contactDetailService.TGetAll();
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateContactDetail(ContactDetail contactDetail)
        {
            _contactDetailService.TUpdate(contactDetail);
            return Ok("Başarıyla güncellendi");
        }

        [HttpGet("GetContactDetail")]

        public IActionResult GetContactDetail(int id)
        {
            var value = _contactDetailService.TGetById(id);
            return Ok(value);
        }
    }
}
