using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.Dtos.ContactDto;
using Newtonsoft.Json;
using System.Text;

namespace MilkyProject.WebUI.Areas.UI.Controllers
{
    [Area("UI")]
    public class UIContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UIContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDto createContactDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7202/api/Contact", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Redirect("/UI/UIContact/Index/");
            }
            return View();
        }
    }
}
