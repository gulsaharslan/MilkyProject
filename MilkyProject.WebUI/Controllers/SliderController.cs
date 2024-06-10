using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.Dtos.CategoryDto;
using MilkyProject.WebUI.Dtos.CategoryDtos;
using MilkyProject.WebUI.Dtos.EmployeeDto;
using MilkyProject.WebUI.Dtos.GalleryDto;
using MilkyProject.WebUI.Dtos.SliderDto;
using Newtonsoft.Json;
using System.Text;

namespace MilkyProject.WebUI.Controllers
{
    public class SliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SliderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> SliderList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7202/api/Slider");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateSlider()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateSlider(CreateSliderDto createSliderDto, IFormFile imageUrl)
        {
            string uniqueName = Guid.NewGuid().ToString();
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload", uniqueName + imageUrl.FileName);
            using (var folder = new FileStream(imagePath, FileMode.Create))
            {
                await imageUrl.CopyToAsync(folder);
            }
            string uniqeImageUrl = uniqueName + imageUrl.FileName;
            var client = _httpClientFactory.CreateClient();
            createSliderDto.imageUrl = uniqeImageUrl;
            var jsonData = JsonConvert.SerializeObject(createSliderDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7202/api/Slider", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SliderList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteSlider(int id)
        {
            var imageUrl = "";
            var client = _httpClientFactory.CreateClient();
            var sliderResponse = await client.GetAsync("https://localhost:7202/api/Slider/GetSlider?id=" + id);
            if (sliderResponse.IsSuccessStatusCode)
            {
                var jsonData = await sliderResponse.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultSliderDto>(jsonData);
                imageUrl = value.imageUrl;
            }
         
            var responseMessage = await client.DeleteAsync("https://localhost:7202/api/Slider?id=" + id);
            if (responseMessage.IsSuccessStatusCode && imageUrl != "")
            {

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload", imageUrl);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                return RedirectToAction("SliderList");
            }
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> UpdateSlider(int id)
        {
            
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7202/api/Slider/GetSlider?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSliderDto>(jsonData);
             
                return View(values);

            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSliderDto, IFormFile imageUrl)
        {
            string uniqueName = Guid.NewGuid().ToString();
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload", uniqueName + imageUrl.FileName);
            using (var folder = new FileStream(imagePath, FileMode.Create))
            {
                await imageUrl.CopyToAsync(folder);
            }
            string uniqeImageUrl = uniqueName + imageUrl.FileName;

            var client = _httpClientFactory.CreateClient();
            updateSliderDto.imageUrl = uniqeImageUrl;

            var jsonData = JsonConvert.SerializeObject(updateSliderDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7202/api/Slider/UpdateSlider", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload", updateSliderDto.oldImageUrl);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                return RedirectToAction("SliderList");
            }
            return View();
        }
    }
}
