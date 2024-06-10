namespace MilkyProject.WebUI.Dtos.EmployeeDto
{
    public class UpdateEmployeeDto
    {
       
            public int employeeId { get; set; }
            public string nameSurname { get; set; }
            public string job { get; set; }
            public string imageUrl { get; set; }
            public string oldImageUrl { get; set; }

    }
}
