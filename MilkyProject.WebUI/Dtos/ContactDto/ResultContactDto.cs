namespace MilkyProject.WebUI.Dtos.ContactDto
{
    public class ResultContactDto
    {
            public int contactId { get; set; }
            public string nameSurname { get; set; }
            public string email { get; set; }
            public string subject { get; set; }
            public string message { get; set; }
            public DateTime date { get; set; }
        
    }
}
