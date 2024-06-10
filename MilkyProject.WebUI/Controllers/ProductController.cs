using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MilkyProject.WebUI.Dtos.CategoryDto;
using MilkyProject.WebUI.Dtos.CategoryDtos;
using MilkyProject.WebUI.Dtos.EmployeeDto;
using MilkyProject.WebUI.Dtos.GalleryDto;
using MilkyProject.WebUI.Dtos.ProductDto;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;

namespace MilkyProject.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> ProductList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7202/api/Product/GetProductsWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessageCategory = await client.GetAsync("https://localhost:7202/api/Category");
            if (responseMessageCategory.IsSuccessStatusCode)
            {
                var jsonDataCategory = await responseMessageCategory.Content.ReadAsStringAsync();
                var valuesCategory = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonDataCategory);
                List<SelectListItem> categoryList = (from x in valuesCategory
                                                     select new SelectListItem
                                                     {
                                                         Text = x.categoryName,
                                                         Value = x.categoryId.ToString()
                                                     }).ToList();
                ViewBag.CategoryList = categoryList;
            }
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto, IFormFile imageUrl)

        {
            string uniqueName = Guid.NewGuid().ToString();
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload", uniqueName + imageUrl.FileName);
            using (var folder = new FileStream(imagePath, FileMode.Create))
            {
                await imageUrl.CopyToAsync(folder);
            }
            string uniqeImageUrl = uniqueName + imageUrl.FileName;
            var client = _httpClientFactory.CreateClient();
            createProductDto.imageUrl = uniqeImageUrl;
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7202/api/Product", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductList");
            }
            return View();

        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var imageUrl = "";
            var client = _httpClientFactory.CreateClient();
            var productResponse = await client.GetAsync("https://localhost:7202/api/Product/GetProduct?id=" + id);
            if (productResponse.IsSuccessStatusCode)
            {
                var jsonData = await productResponse.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultProductCategoryDto>(jsonData);
                imageUrl = value.ImageUrl;
            }
            var responseMessage = await client.DeleteAsync("https://localhost:7202/api/Product?id=" + id);
            if (responseMessage.IsSuccessStatusCode && imageUrl!="")
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload", imageUrl);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                return RedirectToAction("ProductList");
            }
            return View();

        }


        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
           

            var client = _httpClientFactory.CreateClient();
            var responseMessageCategory = await client.GetAsync("https://localhost:7202/api/Category");
            if (responseMessageCategory.IsSuccessStatusCode)
            {
                var jsonDataCategory = await responseMessageCategory.Content.ReadAsStringAsync();
                var valuesCategory = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonDataCategory);
                List<SelectListItem> categoryList = (from x in valuesCategory
                                                     select new SelectListItem
                                                     {
                                                         Text = x.categoryName,
                                                         Value = x.categoryId.ToString()
                                                     }).ToList();
                ViewBag.CategoryList = categoryList;
            }
            var responseMessage = await client.GetAsync("https://localhost:7202/api/Product/GetProduct?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                return View(values);
            }
           

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto, IFormFile imageUrl)
        {
            string uniqueName = Guid.NewGuid().ToString();
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload", uniqueName + imageUrl.FileName);
            using (var folder = new FileStream(imagePath, FileMode.Create))
            {
                await imageUrl.CopyToAsync(folder);
            }
            string uniqeImageUrl = uniqueName + imageUrl.FileName;

            var client = _httpClientFactory.CreateClient();
            updateProductDto.imageUrl = uniqeImageUrl;

            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7202/api/Product/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/upload", updateProductDto.oldImageUrl);
                if (System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }
                return RedirectToAction("ProductList");
            }
            else
            {
                ModelState.AddModelError("", "Ürün güncelleme işlemi sırasında bir hata oluştu.");
                return View(updateProductDto);
            }

        }




    }
}
