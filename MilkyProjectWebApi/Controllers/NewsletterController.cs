using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsletterController : ControllerBase
    {
        private readonly INewsletterService _newsletterService;

        public NewsletterController(INewsletterService newsletterService)
        {
            _newsletterService = newsletterService;
        }

        [HttpGet]
        public IActionResult NewsletterList()
        {
            var values = _newsletterService.TGetAll();
            return Ok(values);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _newsletterService.TDelete(id);
            return Ok("Başarıyla silindi");
        }

        [HttpGet("GetNewsletter")]
        public IActionResult GetNewsletter(int id) 
        {
            var values=_newsletterService.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateNewsletter(Newsletter newsletter)
        {
           _newsletterService.TInsert(newsletter);
            return Ok("Başarıyla eklendi");
        }
    }
}
