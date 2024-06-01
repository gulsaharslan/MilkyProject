using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.Dtos.EmployeeDto;
using MilkyProject.WebUI.Dtos.ProductDto;
using Newtonsoft.Json;

namespace MilkyProject.WebUI.Areas.UI.Controllers
{
    [Area("UI")]
    public class UIEmployeeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UIEmployeeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult>Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7202/api/Employee");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(jsonData);
                return View(value);
            }
            return View();
        }
    }
}
