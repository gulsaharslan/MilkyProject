using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUI.Areas.UI.ViewComponents._UILayoutViewComponents
{
    [Area("UI")]
    public class _UILayoutOpenHoursComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
