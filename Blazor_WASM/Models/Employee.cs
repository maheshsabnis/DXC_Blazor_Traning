using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor_WASM.Models
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public string DeptName { get; set; }
    }



    public class Employees : List<Employee>
    {
        public Employees()
        {
            Add(new Employee() { EmpNo=1,EmpName="A", DeptName="IT"});
            Add(new Employee() { EmpNo = 2, EmpName = "B",DeptName="HR" });
        }
    }
}
