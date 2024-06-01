using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.Dtos.AboutDto;
using MilkyProject.WebUI.Dtos.ContactDetailDto;
using Newtonsoft.Json;

namespace MilkyProject.WebUI.Areas.UI.ViewComponents._UILayoutViewComponents
{
    [Area("UI")]
    public class _UILayoutFooterComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutFooterComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7202/api/ContactDetail");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDetailDto>>(jsonData);
                return View(values.FirstOrDefault());
            }
            return View();
            
        }
    }
}
