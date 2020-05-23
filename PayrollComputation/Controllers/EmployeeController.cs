using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PayrollComputation.Models;
using PayrollComputation.Services;

namespace PayrollComputation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeServices;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeServices = employeeService;
        }
        public IActionResult Index()
        {
            var employee = _employeeServices.GetAll().Select(employee => new EmployeeIndexViewModel
            {
                Id = employee.Id,
                EmpId=employee.EmpId,
                FullName=employee.Fullname,
                Designation=employee.Designation,
                ImageUrl=employee.ImageUrl,
                DOJ=employee.DOJ,
                Gender=employee.Gender,
                City=employee.City
            }).ToList();
            
            return View(employee);
        }
    }
}