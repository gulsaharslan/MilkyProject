using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }
        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _socialMediaService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateSocialMedia(SocialMedia socialMedia)
        {
            _socialMediaService.TInsert(socialMedia);
            return Ok("Başarıyla eklendi");
        }

        [HttpDelete]

        public IActionResult DeleteSocialMedia(int id)
        {
            _socialMediaService.TDelete(id);
            return Ok("Başarıyla silindi");
        }

        [HttpPut("UpdateSocialMedia")]

        public IActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            _socialMediaService.TUpdate(socialMedia);
            return Ok("Başarıyla güncellendi");
        }

        [HttpGet("GetSocialMedia")]

        public IActionResult GetSocialMedia(int id)
        {
            var value = _socialMediaService.TGetById(id);
            return Ok(value);
        }

        [HttpGet("GetSocialMediaWithEmployee")]

        public IActionResult GetSocialMediaWithEmployee()
        {
            var values = _socialMediaService.TGetSocialMediaWithEmployee();
            return Ok(values);
        }
    }
}
