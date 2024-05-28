using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.WebUI.Dtos.TestimonialDto;

namespace MilkyProject.WebUI.ViewComponents._DasboardViewComponents
{
    public class _TestimonialComponentPartial:ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public _TestimonialComponentPartial(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _testimonialService.TGetAll();
            return View(values);
        }
    }
}
