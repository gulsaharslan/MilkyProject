using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.Dtos.GalleryDto;
using MilkyProject.WebUI.Dtos.TestimonialDto;
using Newtonsoft.Json;

namespace MilkyProject.WebUI.Areas.UI.ViewComponents.DefaultViewComponents
{
    public class DefaultTestimonialComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultTestimonialComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7202/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    
    }
}
