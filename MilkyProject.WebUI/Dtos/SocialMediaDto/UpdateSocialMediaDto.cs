namespace MilkyProject.WebUI.Dtos.SocialMediaDto
{
    public class UpdateSocialMediaDto
    {
        public int socialMediaId { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string icon { get; set; }
        public int? employeeId { get; set; }
       
    }
}
