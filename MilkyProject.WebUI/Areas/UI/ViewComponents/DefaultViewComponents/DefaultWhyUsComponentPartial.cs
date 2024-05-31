using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.Dtos.AboutDto;
using MilkyProject.WebUI.Dtos.WhyUsDto;
using Newtonsoft.Json;

namespace MilkyProject.WebUI.Areas.UI.ViewComponents.DefaultViewComponents
{
    public class DefaultWhyUsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultWhyUsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7202/api/WhyUs");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultWhyUsDto>>(jsonData);
                return View(values.FirstOrDefault());
            }
            return View();
        }
    }
}
