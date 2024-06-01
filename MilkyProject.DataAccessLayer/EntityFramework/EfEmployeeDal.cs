using MilkyProject.DataAccessLayer.Abstract;
using MilkyProject.DataAccessLayer.Context;
using MilkyProject.DataAccessLayer.Repositories;
using MilkyProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.DataAccessLayer.EntityFramework
{
    public class EfEmployeeDal : GenericRepository<Employee>, IEmployeeDal
    {
        public EfEmployeeDal(MilkyContext context) : base(context)
        {
        }

        public int GetEmployeeCount()
        {
            var context = new MilkyContext();
            var values = context.Employees.Count();
            return values;
        }

        public List<Employee> GetEmployeeLast3()
        {
            var context = new MilkyContext();
            var value = context.Employees
            .OrderByDescending(p => p.EmployeeId)
            .Take(3)
            .ToList();
            return value;
        }
    }
}
