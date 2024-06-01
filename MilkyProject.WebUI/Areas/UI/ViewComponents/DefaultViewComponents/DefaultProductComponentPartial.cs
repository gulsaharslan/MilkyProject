using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.Dtos.GalleryDto;
using MilkyProject.WebUI.Dtos.ProductDto;
using Newtonsoft.Json;

namespace MilkyProject.WebUI.Areas.UI.ViewComponents.DefaultViewComponents
{
    public class DefaultProductComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultProductComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7202/api/Product/GetProductsLast5");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
