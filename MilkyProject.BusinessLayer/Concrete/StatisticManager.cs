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
    public class StatisticManager : IStatisticService
    {
        private readonly IStatisticDal _statisticDal;

        public StatisticManager(IStatisticDal statisticDal)
        {
            _statisticDal = statisticDal;
        }

        public void TDelete(int id)
        {
            _statisticDal.Delete(id);
        }

        public List<Statistic> TGetAll()
        {
            return _statisticDal.GetAll();
        }

        public Statistic TGetById(int id)
        {
            return _statisticDal.GetById(id);
        }

        public void TInsert(Statistic entity)
        {
           _statisticDal.Insert(entity);
        }

        public void TUpdate(Statistic entity)
        {
            _statisticDal.Update(entity);
        }
    }
}
