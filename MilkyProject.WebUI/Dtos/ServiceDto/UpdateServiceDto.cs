namespace MilkyProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int serviceId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string imageUrl { get; set; }
        public string smallImageUrl { get; set; }
    }
}
