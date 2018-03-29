using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _7DayTutorial.DataAccessLayer;

namespace _7DayTutorial.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            var salesDal = new SalesErpdal();
            return salesDal.Employees.ToList();
        }

        public Employee SaveEmployee(Employee e)
        {
            var salesDal = new SalesErpdal();
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            return e;
        }
    }
}