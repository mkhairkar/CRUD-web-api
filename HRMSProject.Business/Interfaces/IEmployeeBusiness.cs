using HRMSProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.Business.Interfaces
{
    public interface IEmployeeBusiness
    {
        Task<List<EmployeeVM>> GetAllEmployees();
        Task<EmployeeVM> InsertEmployee(EmployeeVM emp);
        Task<List<DeptEmpVM>> GetEmpDetails(int? DeptId);

        Task<EmployeeVM> DeleteEmployee(int? EmpId);
        Task<EmployeeVM> UpdateEmployee(EmployeeVM emp);

    }
}
