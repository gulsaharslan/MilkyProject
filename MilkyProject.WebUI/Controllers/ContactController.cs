using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.Dtos.CategoryDto;
using MilkyProject.WebUI.Dtos.CategoryDtos;
using MilkyProject.WebUI.Dtos.ContactDto;
using Newtonsoft.Json;
using System.Text;

namespace MilkyProject.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7202/api/Contact");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return View(values);
            }
            return View();
        }


        public async Task<IActionResult> DeleteContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7202/api/Contact?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
