using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUI.ViewComponents._AdminLayoutViewComponents
{
    public class _AdminLayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
