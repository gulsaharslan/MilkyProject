namespace MilkyProject.WebUI.Dtos.ProductDto
{
    public class UpdateProductDto
    {
        public int productId { get; set; }

        public string productName { get; set; }
        public decimal oldPrice { get; set; }
        public decimal newPrice { get; set; }
        public string imageUrl { get; set; }
        public bool status { get; set; }
        public int? CategoryId { get; set; }

    }
}
