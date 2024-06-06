using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.WebUI.Dtos.ContactDetailDto;
using MilkyProject.WebUI.Dtos.GalleryDto;
using Newtonsoft.Json;

namespace MilkyProject.WebUI.Areas.UI.ViewComponents.DefaultViewComponents
{
    public class DefaultContactDetailComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultContactDetailComponentPartial(IHttpClientFactory httpClientFactory)
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
                return View(values);
            }
            return View();
        }
    }
}
