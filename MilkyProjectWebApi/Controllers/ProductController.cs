using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;

namespace MilkyProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    { private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]

        public IActionResult ProductList()
        {
            var values = _productService.TGetAll();
            return Ok(values);
        }

        [HttpPost]

        public IActionResult CreateProduct(Product product)
        {
            _productService.TInsert(product);
            return Ok("Ürün başarıyla eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            _productService.TDelete(id);
            return Ok("Ürün başarıyla silindi");
        }

        [HttpGet("GetProduct")]

        public IActionResult GetProduct(int id)
        {
           var value= _productService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]

        public IActionResult UpdateProduct(Product product)
        {
            _productService.TUpdate(product);
            return Ok("Ürün başarıyla güncellendi");
        }

        [HttpGet("GetProductsWithCategory")]

        public IActionResult GetProductsWithCategory()
        {
            var values = _productService.TGetProductsWithCategory();
            return Ok(values);
        }

    }
}
