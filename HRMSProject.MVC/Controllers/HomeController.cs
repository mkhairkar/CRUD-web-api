using HRMSProject.Business.Interfaces;
using HRMSProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSProject.MVC.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeBusiness _employeeBusiness;

        public HomeController(IEmployeeBusiness employeeBusiness)
        {
            _employeeBusiness = employeeBusiness;
        }

        public async Task<IActionResult> Index()
        {
            List<EmployeeVM> employees = await _employeeBusiness.GetAllEmployees();
            return View(employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeVM emp)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _employeeBusiness.InsertEmployee(emp);
            return View(result);
        }

        public async Task<IActionResult> GetEmpDetails(int? DeptId)
        {
            var result = await _employeeBusiness.GetEmpDetails(DeptId);
            return View(result);
        }

        public async Task<IActionResult> Delete(int EmpId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _employeeBusiness.DeleteEmployee(EmpId);

            return View(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
