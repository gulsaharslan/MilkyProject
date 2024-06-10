using Microsoft.AspNetCore.Mvc;
using MilkyProject.WebUI.Dtos.CategoryDto;
using MilkyProject.WebUI.Dtos.CategoryDtos;
using MilkyProject.WebUI.Dtos.EmployeeDto;
using MilkyProject.WebUI.Dtos.GalleryDto;
using Newtonsoft.Json;
using System.Text;

namespace MilkyProject.WebUI.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public EmployeeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> EmployeeList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7202/api/Employee");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto, IFormFile imageUrl)
        {
            string uniqueName = Guid.NewGuid().ToString();
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload", uniqueName + imageUrl.FileName);
            using (var folder = new FileStream(imagePath, FileMode.Create))
            {
                await imageUrl.CopyToAsync(folder);
            }
            string uniqeImageUrl = uniqueName + imageUrl.FileName;
            var client = _httpClientFactory.CreateClient();
            createEmployeeDto.imageUrl = uniqeImageUrl;
            var jsonData = JsonConvert.SerializeObject(createEmployeeDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7202/api/Employee", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("EmployeeList");
            }
            return View();
        }

        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var imageUrl = "";
            var client = _httpClientFactory.CreateClient();
            var galleryResponse = await client.GetAsync("https://localhost:7202/api/Employee/GetEmployee?id=" + id);
            if (galleryResponse.IsSuccessStatusCode)
            {
                var jsonData = await galleryResponse.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultEmployeeDto>(jsonData);
                imageUrl = value.imageUrl;
            }
            var responseMessage = await client.DeleteAsync("https://localhost:7202/api/Employee?id=" + id);
            if (responseMessage.IsSuccessStatusCode && imageUrl!="")
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload", imageUrl);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                return RedirectToAction("EmployeeList");
            }
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7202/api/Employee/GetEmployee?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateEmployeeDto>(jsonData);
                return View(values);

            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto, IFormFile imageUrl)
        {
            string uniqueName = Guid.NewGuid().ToString();
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload", uniqueName + imageUrl.FileName);
            using (var folder = new FileStream(imagePath, FileMode.Create))
            {
                await imageUrl.CopyToAsync(folder);
            }
            string uniqeImageUrl = uniqueName + imageUrl.FileName;

            var client = _httpClientFactory.CreateClient();
            updateEmployeeDto.imageUrl = uniqeImageUrl;

            var jsonData = JsonConvert.SerializeObject(updateEmployeeDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7202/api/Employee", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload", updateEmployeeDto.oldImageUrl);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                return RedirectToAction("EmployeeList");
            }
            return View();

        }
    }
}

