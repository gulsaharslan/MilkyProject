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
    public class EfContactDetailDal : GenericRepository<ContactDetail>, IContactDetailDal
    {
        public EfContactDetailDal(MilkyContext context) : base(context)
        {
        }
    }
}
