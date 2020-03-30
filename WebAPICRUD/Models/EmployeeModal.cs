using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPICRUD.Models
{
    public class EmployeeModal
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string Email { get; set; }
        public int Salary { get; set; }
    }
}