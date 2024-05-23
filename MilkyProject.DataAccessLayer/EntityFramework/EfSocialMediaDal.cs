using Microsoft.EntityFrameworkCore;
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
    public class EfSocialMediaDal : GenericRepository<SocialMedia>, ISocialMediaDal
    {
        public EfSocialMediaDal(MilkyContext context) : base(context)
        {
        }

        public List<SocialMedia> GetSocialMediaWithEmployee()
        {
            var context = new MilkyContext();
            var values = context.SocialMedias.Include(x => x.Employee).Select(y => new SocialMedia
            {
                Name = y.Name,
                Url = y.Url,
                EmployeeId = y.EmployeeId,
                Icon = y.Icon,
                SocialMediaId = y.SocialMediaId,
                Employee = new Employee { NameSurname = y.Employee.NameSurname }
            }).ToList();
            return values;
        }
    }
}
