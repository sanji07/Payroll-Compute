using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using PayrollComputation.Entity;
using PayrollComputation.Models;
using PayrollComputation.Services;

namespace PayrollComputation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeServices;
        private readonly HostingEnvironment _hostingEnvironment;
        public EmployeeController(IEmployeeService employeeService, HostingEnvironment hostingEnvironment)
        {
            _employeeServices = employeeService;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            var employee = _employeeServices.GetAll().Select(employee => new EmployeeIndexViewModel
            {
                Id = employee.Id,
                EmpId = employee.EmpId,
                FullName = employee.Fullname,
                Designation = employee.Designation,
                ImageUrl = employee.ImageUrl,
                DOJ = employee.DOJ,
                Gender = employee.Gender,
                City = employee.City
            }).ToList();

            return View(employee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var model = new EmployeeCreateViewModel();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new EmployeeDet
                {
                    Id = model.Id,
                    EmpId = model.EmpId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Fullname = model.Fullname,
                    Gender = model.Gender,
                    Email = model.Email,
                    DOB = model.DOB,
                    DOJ = model.DOJ,
                    Designation = model.Designation,
                    TFN = model.TFN,
                    paymentMethod = model.paymentMethod,
                    studentLoan = model.studentLoan,
                    Address = model.Address,
                    Phone = model.Phone,
                    City = model.City,
                    POcode = model.POcode
                };
                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadDir = @"images/employee";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var extension = Path.GetExtension(model.ImageUrl.FileName);
                    var webRootPath = _hostingEnvironment.ContentRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + uploadDir + "/" + fileName;
                }
                await _employeeServices.CreateAsync(employee);
                return RedirectToAction(nameof(Index));


            }
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}