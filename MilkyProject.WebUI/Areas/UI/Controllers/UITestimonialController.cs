using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.Dtos.AboutDto;
using MilkyProject.WebUI.Dtos.TestimonialDto;
using Newtonsoft.Json;

namespace MilkyProject.WebUI.Areas.UI.Controllers
{
    [Area("UI")]
    public class UITestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UITestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
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
