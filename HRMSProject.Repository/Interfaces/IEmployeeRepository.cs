using HRMSProject.Repository.Models;
using HRMSProject.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployees();
        Task<Employee> InsertEmployee(Employee emp);
        Task<List<DeptEmp>> GetEmpDetails(int? DeptId);
        Task<Employee> DeleteEmployee(int? EmpId);

        Task<Employee> UpdateEmployee(Employee emp);


    }
}
