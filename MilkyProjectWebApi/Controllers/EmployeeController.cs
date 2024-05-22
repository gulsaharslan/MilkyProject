using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult EmployeeList()
        {
            var values=_employeeService.TGetAll();
            return Ok(values);

        }

        [HttpPost]
        public IActionResult CreateEmployee(Employee employee)
        {
            _employeeService.TInsert(employee);
            return Ok("Başarıyla eklendi");

        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            _employeeService.TDelete(id);
            return Ok("Başarıyla silindi");
        }

        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            _employeeService.TUpdate(employee);
            return Ok("Başarıyla güncellendi");
        }

        [HttpGet("GetEmployee")]
        public IActionResult GetEmployee(int id)
        {
           var value= _employeeService.TGetById(id);
            return Ok(value);
        }
    }
}
