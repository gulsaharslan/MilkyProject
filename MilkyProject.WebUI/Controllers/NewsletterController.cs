using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.Dtos.NewsletterDto;
using Newtonsoft.Json;

namespace MilkyProject.WebUI.Controllers
{
    public class NewsletterController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public NewsletterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult>NewsletterList()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7202/api/Newsletter");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultNewsletterDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> DeleteNewsletter(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7202/api/Newsletter?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("NewsletterList");
            }
            return View();
        }
    }
}
