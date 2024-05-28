using Microsoft.AspNetCore.Mvc;
using MilkyProject.DataAccessLayer.Context;

namespace MilkyProject.WebUI.ViewComponents._DasboardViewComponents
{
    public class _ChartComponentPartial:ViewComponent
    {
        private readonly MilkyContext _context;

        public _ChartComponentPartial(MilkyContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _context.Categories.ToList();

            var data = new[]
            {
                new object[] { "Kategori Adı", "Ürün Sayısı" }
            };

            foreach (var category in categories)
            {
                var categoryCount = _context.Products.Count(b => b.CategoryId == category.CategoryId);
                data = data.Append(new object[] { category.CategoryName, categoryCount }).ToArray();
            }

            ViewBag.CategoriesData = data;

            return View();
        }
    }
}
