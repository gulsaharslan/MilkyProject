﻿using MilkyProject.BusinessLayer.Abstract;
using MilkyProject.DataAccessLayer.Abstract;
using MilkyProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilkyProject.BusinessLayer.Concrete
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeDal _employeeDal;

        public EmployeeManager(IEmployeeDal employeeDal)
        {
            _employeeDal = employeeDal;
        }

        public void TDelete(int id)
        {
           _employeeDal.Delete(id);
        }

        public List<Employee> TGetAll()
        {
           return _employeeDal.GetAll();
        }

        public Employee TGetById(int id)
        {
           return _employeeDal.GetById(id);
        }

        public void TInsert(Employee entity)
        {
           _employeeDal.Insert(entity);
        }

        public void TUpdate(Employee entity)
        {
           _employeeDal.Update(entity);
        }
    }
}
