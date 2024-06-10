using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.Dtos.CategoryDtos;
using MilkyProject.WebUI.Dtos;
using Newtonsoft.Json;
using System.Text;
using MilkyProject.WebUI.Dtos.GalleryDto;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProject.WebUI.Controllers
{
    public class GalleryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GalleryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> GalleryList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7202/api/Gallery");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultGalleryDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateGallery()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateGallery(CreateGalleryDto createGalleryDto, IFormFile imageUrl)
        {
            string uniqueName = Guid.NewGuid().ToString();
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload", uniqueName + imageUrl.FileName);
            using (var folder = new FileStream(imagePath, FileMode.Create))
            {
                await imageUrl.CopyToAsync(folder);
            }
            string uniqeImageUrl = uniqueName + imageUrl.FileName;
            var client = _httpClientFactory.CreateClient();
            createGalleryDto.imageUrl = uniqeImageUrl;
            var jsonData = JsonConvert.SerializeObject(createGalleryDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7202/api/Gallery", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("GalleryList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteGallery(int id)
        {
            var imageUrl = "";
            var client = _httpClientFactory.CreateClient();
            var galleryResponse = await client.GetAsync("https://localhost:7202/api/Gallery/GetGallery?id=" + id);
            if (galleryResponse.IsSuccessStatusCode)
            {
                var jsonData = await galleryResponse.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultGalleryDto>(jsonData);
                imageUrl = value.imageUrl;
            }

            var responseMessage = await client.DeleteAsync("https://localhost:7202/api/Gallery?id=" + id);
            if (responseMessage.IsSuccessStatusCode && imageUrl!="")
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload", imageUrl);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                return RedirectToAction("GalleryList");
            }
            return View();
        }

    }
}
