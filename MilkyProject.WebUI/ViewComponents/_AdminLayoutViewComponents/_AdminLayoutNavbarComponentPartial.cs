using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUI.ViewComponents._AdminLayoutViewComponents
{
    public class _AdminLayoutNavbarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
