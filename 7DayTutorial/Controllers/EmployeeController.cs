using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using _7DayTutorial.Models;
using _7DayTutorial.ViewModels;

namespace _7DayTutorial.Controllers
{


    public class EmployeeController : Controller
    {

        // GET: Test
        [Route("employee/index")]
        public ActionResult Index()
        {
            var employeeListViewModel = new EmployeeListViewModel();
            var empBal = new EmployeeBusinessLayer();
            var employees = empBal.GetEmployees();
            var empViewModels = new List<EmployeeViewModel>();

            foreach (var emp in employees)
            {
                var empViewModel = new EmployeeViewModel
                {
                    EmployeeName = emp.FirstName + " " + emp.LastName,
                    Salary = emp.Salary.ToString("C"),
                    SalaryColour = (emp.Salary > 15000) ? "yellow" : "green"
                };
                empViewModels.Add(empViewModel);
            }

            employeeListViewModel.Employees = empViewModels;
            return View(employeeListViewModel);
        }

        [Route("employee/create")]
        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Save(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        var empBal = new EmployeeBusinessLayer();
                        empBal.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return View("Create");
                    }
                case "Cancel":
                    return RedirectToAction("Index");
                default:
                    return new EmptyResult();
            }
        }
    }
}