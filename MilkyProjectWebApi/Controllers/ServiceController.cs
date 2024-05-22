using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _serviceService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _serviceService.TInsert(service);
            return Ok("Başarıyla eklendi");
        }

        [HttpDelete]

        public IActionResult DeleteService(int id)
        {
            _serviceService.TDelete(id);
            return Ok("Başarıyla silindi");
        }

        [HttpPut("UpdateService")]

        public IActionResult UpdateService(Service service)
        {
            _serviceService.TUpdate(service);
            return Ok("Başarıyla güncellendi");
        }

        [HttpGet("GetService")]

        public IActionResult GetService(int id)
        {
            var value = _serviceService.TGetById(id);
            return Ok(value);
        }
    }
}
