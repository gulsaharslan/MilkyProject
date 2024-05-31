using MilkyProject.EntityLayer.Concrete;
using MilkyProject.WebUI.Dtos.SocialMediaDto;

namespace MilkyProject.WebUI.Dtos.EmployeeDto
{
    public class ResultEmployeeDto
    {
        public int employeeId { get; set; }
        public string nameSurname { get; set; }
        public string job { get; set; }
        public string imageUrl { get; set; }

        public ResultSocialMediaDto SocialMediaDto { get; set; } = new ResultSocialMediaDto();


        public class ResultSocialMediaDto
        {
            public string url { get; set; }
            public string icon { get; set; }

        }

    }
}
