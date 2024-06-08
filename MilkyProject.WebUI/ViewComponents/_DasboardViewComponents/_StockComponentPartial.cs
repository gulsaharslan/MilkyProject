using Microsoft.AspNetCore.Mvc;
using MilkyProject.BusinessLayer.Abstract;

namespace MilkyProject.WebUI.ViewComponents._DasboardViewComponents
{
    public class _StockComponentPartial:ViewComponent
    {
        private readonly IProductService _productService;

        public _StockComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            var value = _productService.TGetAll();
            return View(value);
        }
    }
}
