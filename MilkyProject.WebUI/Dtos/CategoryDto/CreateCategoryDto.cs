using MilkyProject.WebUI.Dtos.ProductDto;

namespace MilkyProject.WebUI.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }
        public ResultProductDto? Product { get; set; }
    }
}
