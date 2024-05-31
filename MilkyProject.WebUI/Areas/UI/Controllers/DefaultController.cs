using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUI.Areas.UI.Controllers
{
    [Area("UI")]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
