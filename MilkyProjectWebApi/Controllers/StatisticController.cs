using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;

namespace MilkyProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IEmployeeService _employeeService;
        private readonly INewsletterService _newsletterService;

        public StatisticController(ICategoryService categoryService, IProductService productService, IEmployeeService employeeService, INewsletterService newsletterService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _employeeService = employeeService;
            _newsletterService = newsletterService;
        }

        [HttpGet("StatisticCount")]
        public IActionResult StatisticCount()
        {
            // Kategorilerin, ürünlerin, çalışanların ve bültenlerin sayılarını alın
            var categoryCount = _categoryService.TGetCategoryCount();
            var productCount = _productService.TGetProductCount();
            var employeeCount = _employeeService.TGetEmployeeCount();
            var newsletterCount = _newsletterService.TGetNewsletterCount();

            var statistics = new
            {
                CategoryCount = categoryCount,
                ProductCount = productCount,
                EmployeeCount = employeeCount,
                NewsletterCount = newsletterCount
            };

            // JSON formatında istemciye gönderin
            return Ok(statistics);
        }
    }
}
