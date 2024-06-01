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
    public class EfServiceDal : GenericRepository<Service>, IServiceDal
    {
        public EfServiceDal(MilkyContext context) : base(context)
        {
        }

        public List<Service> GetServiceLast3()
        {
            var context = new MilkyContext();
            var value = context.Services
            .OrderByDescending(p => p.ServiceId)
            .Take(3)
            .ToList();
            return value;
        }
    }
}
