using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.DataAccessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.BusinessLayer.Concrete
{
    public class ContactDetailManager : IContactDetailService
    {
        private readonly IContactDetailDal _contactDetailDal;

        public ContactDetailManager(IContactDetailDal contactDetailDal)
        {
            _contactDetailDal = contactDetailDal;
        }

        public void TDelete(int id)
        {
            _contactDetailDal.Delete(id);
        }

        public List<ContactDetail> TGetAll()
        {
            return _contactDetailDal.GetAll();
        }

        public ContactDetail TGetById(int id)
        {
            return _contactDetailDal.GetById(id);
        }

        public void TInsert(ContactDetail entity)
        {
            _contactDetailDal.Insert(entity);
        }

        public void TUpdate(ContactDetail entity)
        {
            _contactDetailDal.Update(entity);
        }
    }
}
