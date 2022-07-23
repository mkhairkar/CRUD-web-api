using AutoMapper;
using HRMSProject.Business.Interfaces;
using HRMSProject.Models;
using HRMSProject.Repository.Interfaces;
using HRMSProject.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.Business
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeBusiness(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeVM>> GetAllEmployees()
        {
            List<Employee> list = await _employeeRepository.GetAllEmployees();
            return _mapper.Map<List<EmployeeVM>>(list);
        }

        public async Task<EmployeeVM> InsertEmployee(EmployeeVM emp)
        {
            var result = await _employeeRepository.InsertEmployee(_mapper.Map<Employee>(emp));
            return _mapper.Map<EmployeeVM>(result);
        }

        public async Task<List<DeptEmpVM>> GetEmpDetails(int? DeptId)
        {
            var list = await _employeeRepository.GetEmpDetails(DeptId);
            return _mapper.Map<List<DeptEmpVM>>(list);
        }

        public async Task<EmployeeVM> DeleteEmployee(int? EmpId)
        {
            var result = await _employeeRepository.DeleteEmployee(_mapper.Map<int>(EmpId));
            return _mapper.Map<EmployeeVM>(result);
        }
        public async Task<EmployeeVM> UpdateEmployee(EmployeeVM emp)
        {
            var result = await _employeeRepository.UpdateEmployee(_mapper.Map<Employee>(emp));
            return _mapper.Map<EmployeeVM>(result);
        }
    }
}
