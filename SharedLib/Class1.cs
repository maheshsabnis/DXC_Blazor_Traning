using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedLib
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DeptNo { get; set; }
        public string DeptName { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }

    public partial class Employee
    {
        [Required(ErrorMessage = "EmpNo is Must")]
        public int EmpNo { get; set; }
        [Required(ErrorMessage = "EmpName is Must")]
        public string EmpName { get; set; }
        [Required(ErrorMessage = "Designation is Must")]
        public string Designation { get; set; }
        [Required(ErrorMessage = "Salary is Must")]
        public int Salary { get; set; }
        [Required(ErrorMessage = "DeptNo is Must")]
        public int DeptNo { get; set; }

        public virtual Department DeptNoNavigation { get; set; }
    }
}
