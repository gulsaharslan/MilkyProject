using MilkyProject.WebUI.Dtos.EmployeeDto;

namespace MilkyProject.WebUI.Dtos.SocialMediaDto
{
    public class ResultSocialMediaDto
    {
            public int socialMediaId { get; set; }
            public string name { get; set; }
            public string url { get; set; }
            public string icon { get; set; }
            public int employeeId { get; set; }
            public Employee employee{ get; set; }
            public class Employee
        {
            public string nameSurname { get; set; }
        }
        
    }
}
