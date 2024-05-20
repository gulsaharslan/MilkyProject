using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUI.ViewComponents._AdminLayoutViewComponents
{
    public class _AdminLayoutSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
