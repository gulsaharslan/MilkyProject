using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUI.ViewComponents._DasboardViewComponents
{
    public class _CategoryDetailComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
