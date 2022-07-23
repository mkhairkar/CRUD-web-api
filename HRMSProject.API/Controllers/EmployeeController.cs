using HRMSProject.Business.Interfaces;
using HRMSProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBusiness _empBusiness;
        public EmployeeController(IEmployeeBusiness empBusiness)
        {
            _empBusiness = empBusiness;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _empBusiness.GetAllEmployees();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Post(EmployeeVM obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _empBusiness.InsertEmployee(obj);
            return Ok(result);
        }

        [HttpGet("{deptId}")]
        public async Task<IActionResult> Get(int? DeptId = null)
        {
            var employees = await _empBusiness.GetEmpDetails(DeptId);
            return Ok(employees);
        }

        [HttpDelete("{EmpId}")]
        public async Task<IActionResult> DEL(int? EmpId = null)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _empBusiness.DeleteEmployee(EmpId);

            return Ok(result);
        }

        [HttpPut]

        public async Task<IActionResult> upd(EmployeeVM obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = await _empBusiness.UpdateEmployee(obj);
                return Ok(result);

        }



    }
}
