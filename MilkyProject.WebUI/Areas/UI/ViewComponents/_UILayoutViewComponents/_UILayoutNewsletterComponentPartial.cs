using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.WebUI.Dtos.NewsletterDto;

namespace MilkyProject.WebUI.Areas.UI.ViewComponents._UILayoutViewComponents
{
    [Area("UI")]
    public class _UILayoutNewsletterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            
            return View(new CreateNewsletterDto());
        }
       
    }
}
