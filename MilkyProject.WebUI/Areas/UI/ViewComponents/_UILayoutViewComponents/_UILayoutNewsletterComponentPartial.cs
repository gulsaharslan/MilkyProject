using Microsoft.AspNetCore.Mvc;

namespace MilkyProject.WebUI.Areas.UI.ViewComponents._UILayoutViewComponents
{
    [Area("UI")]
    public class _UILayoutNewsletterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
