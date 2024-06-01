using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.Dtos.AboutDto;
using MilkyProject.WebUI.Dtos.EmployeeDto;
using Newtonsoft.Json;

namespace MilkyProject.WebUI.Areas.UI.Controllers
{
    [Area("UI")]
    public class UIGalleryController : Controller
    {

        public IActionResult Index()
        {
            
            return View();
        }
    }
}
