using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;

namespace MilkyProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialService.TGetAll();
            return Ok(values);
        }
        [HttpDelete]

        public IActionResult DeleteTestimonial(int id)
        {
            _testimonialService.TDelete(id);
            return Ok("Başarıyla silindi");
        }
        [HttpGet("GetTestimonialLast3")]
        public IActionResult GetTestimonialLast3()
        {
            var values = _testimonialService.TGetTestimonialLast3();
            return Ok(values);
        }
    }
}
