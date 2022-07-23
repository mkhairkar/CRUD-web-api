using AutoMapper;
using HRMSProject.Models;
using HRMSProject.Repository.Models;
using HRMSProject.Repository.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.Utilities
{
    public class AutoMappingConfig : Profile
    {
        public AutoMappingConfig()
        {
            CreateMap<Employee, EmployeeVM>().ReverseMap();
            CreateMap<DeptEmp, DeptEmpVM>().ReverseMap();
        }
    }
}
