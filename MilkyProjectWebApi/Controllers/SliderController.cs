using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderService _sliderService;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }
        [HttpGet]
        public IActionResult SliderList()
        {
            var values = _sliderService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateSlider(Slider slider)
        {
            _sliderService.TInsert(slider);
            return Ok("Başarıyla eklendi");
        }

        [HttpDelete]

        public IActionResult DeleteSlider(int id)
        {
            _sliderService.TDelete(id);
            return Ok("Başarıyla silindi");
        }

        [HttpPut("UpdateSlider")]

        public IActionResult UpdateSlider(Slider slider)
        {
            _sliderService.TUpdate(slider);
            return Ok("Başarıyla güncellendi");
        }

        [HttpGet("GetSlider")]

        public IActionResult GetSlider(int id)
        {
            var value = _sliderService.TGetById(id);
            return Ok(value);
        }

    }

}
