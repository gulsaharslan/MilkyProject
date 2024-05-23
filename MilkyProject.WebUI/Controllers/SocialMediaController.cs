using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MilkyProject.WebUI.Dtos.CategoryDto;
using MilkyProject.WebUI.Dtos.CategoryDtos;
using MilkyProject.WebUI.Dtos.EmployeeDto;
using MilkyProject.WebUI.Dtos.ProductDto;
using MilkyProject.WebUI.Dtos.SocialMediaDto;
using Newtonsoft.Json;
using System.Text;

namespace MilkyProject.WebUI.Controllers
{
    public class SocialMediaController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SocialMediaController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> SocialMediaList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7202/api/SocialMedia/GetSocialMediaWithEmployee");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateSocialMedia()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessageEmployee = await client.GetAsync("https://localhost:7202/api/Employee");
            if (responseMessageEmployee.IsSuccessStatusCode)
            {
                var jsonDataEmployee = await responseMessageEmployee.Content.ReadAsStringAsync();
                var valuesEmployee = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(jsonDataEmployee);
                List<SelectListItem> employeeList = (from x in valuesEmployee
                                                     select new SelectListItem
                                                     {
                                                         Text = x.nameSurname,
                                                         Value = x.employeeId.ToString()
                                                     }).ToList();
                ViewBag.employee = employeeList;
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createSocialMediaDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7202/api/SocialMedia", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SocialMediaList");
            }
                return View();
        }

        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7202/api/SocialMedia?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SocialMediaList");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var client = _httpClientFactory.CreateClient();

            // Çalışanları dropdown için getir
            var responseMessageEmployee = await client.GetAsync("https://localhost:7202/api/Employee");
            if (responseMessageEmployee.IsSuccessStatusCode)
            {
                var jsonDataEmployee = await responseMessageEmployee.Content.ReadAsStringAsync();
                var valuesEmployee = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(jsonDataEmployee);
                List<SelectListItem> employeeList = valuesEmployee.Select(x => new SelectListItem
                {
                    Text = x.nameSurname,
                    Value = x.employeeId.ToString()
                }).ToList();
                ViewBag.employees = employeeList;
            }

            // Güncellenecek sosyal medya kaydını getir
            var responseMessage = await client.GetAsync($"https://localhost:7202/api/SocialMedia/GetSocialMedia?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSocialMediaDto>(jsonData);
                return View(values);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateSocialMediaDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7202/api/SocialMedia/UpdateSocialMedia", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("SocialMediaList");
            }
            return View();
        }
    }
}
