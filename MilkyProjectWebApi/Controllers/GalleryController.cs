using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GalleryController : ControllerBase
    {
        private readonly IGalleryService _galleryService;

        public GalleryController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }
        [HttpGet]

        public IActionResult GalleryList()
        {
            var values = _galleryService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateGallery(Gallery gallery)
        {
            _galleryService.TInsert(gallery);
            return Ok("Başarıyla eklendi");
        }

        [HttpDelete]

        public IActionResult DeleteGallery(int id)
        {
            _galleryService.TDelete(id);
            return Ok("Başarıyla silindi");
        }

       

        [HttpGet("GetGallery")]

        public IActionResult GetGallery(int id)
        {
            var value = _galleryService.TGetById(id);
            return Ok(value);
        }

    }
}
