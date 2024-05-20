using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.EntityLayer.Concrete
{
    public class ContactDetail
    {
        public int Id { get; set; }
        public string Adress { get; set;}
        public string Phone { get; set;}
        public string Email { get; set; }
        public string BusinessHour { get; set; }
        public string ClosedDay { get; set; }
    }
}
