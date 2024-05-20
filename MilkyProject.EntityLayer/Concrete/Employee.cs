using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.EntityLayer.Concrete
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string NameSurname { get; set; }
        public string Job { get; set; }
        public string ImageUrl { get; set; }
        List<Employee> Employees { get; set;}

    }
}
