using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Dynamic;

namespace MilkyProject.WebUI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task< IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7202/api/Statistic/StatisticCount");
            if(responseMessage.IsSuccessStatusCode)
            { 
            var content = await responseMessage.Content.ReadAsStringAsync();
            dynamic data = JsonConvert.DeserializeObject<ExpandoObject>(content);

            // View'a taşıyacağınız verileri ViewBag'e veya model nesnesine ekleyebilirsiniz
            ViewBag.CategoryCount = data.categoryCount;
            ViewBag.ProductCount = data.productCount;
            ViewBag.EmployeeCount = data.employeeCount;
            ViewBag.NewsletterCount = data.newsletterCount;
         

            return View();
            }
            return View();
        }
    }
}
