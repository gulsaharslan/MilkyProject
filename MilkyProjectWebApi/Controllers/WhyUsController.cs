using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhyUsController : ControllerBase
    {

        private readonly IWhyUsService _whyUsService;

        public WhyUsController(IWhyUsService whyUsService)
        {
            _whyUsService = whyUsService;
        }
        [HttpGet]

        public IActionResult WhyUsList()
        {
            var values = _whyUsService.TGetAll();
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateWhyUs(WhyUs whyUs)
        {
            _whyUsService.TUpdate(whyUs);
            return Ok("Başarıyla güncellendi");
        }

        [HttpGet("GetWhyUs")]

        public IActionResult GetWhyUs(int id)
        {
            var value = _whyUsService.TGetById(id);
            return Ok(value);
        }
    }
}
