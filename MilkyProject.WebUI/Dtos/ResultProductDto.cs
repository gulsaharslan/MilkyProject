namespace MilkyProject.WebUI.Dtos
{
    public class ResultProductDto
    {

            public int productId { get; set; }
            public string productName { get; set; }
            public decimal oldPrice { get; set; }
            public decimal newPrice { get; set; }
            public string imageUrl { get; set; }
            public bool status { get; set; }
        

    }
}
