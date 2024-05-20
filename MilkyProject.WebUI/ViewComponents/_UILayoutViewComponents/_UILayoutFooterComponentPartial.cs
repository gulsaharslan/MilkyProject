using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUI.ViewComponents._UILayoutViewComponents
{
    public class _UILayoutFooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
