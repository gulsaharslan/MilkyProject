using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.Dtos.ServiceDto;
using Newtonsoft.Json;

namespace MilkyProject.WebUI.Areas.UI.Controllers
{
    [Area("UI")]
    public class UIServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UIServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7202/api/Service");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var value=JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
