using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSProject.Models
{
    public class EmployeeVM
    {
        public int EmpId { get; set; }


        [Required(ErrorMessage ="Dept Id is Mandatory")]
        public int DeptId { get; set; }


        [Required(ErrorMessage ="Emp Name is required")]
        [MinLength(6,ErrorMessage ="Min 6 characters required")]
        [MaxLength(10, ErrorMessage ="Max length is 10 charcaters")]
        public string EmpName { get; set; }


        [Required(ErrorMessage ="EmpSalary is required")]
        public decimal EmpSalary { get; set; }
    }
}
