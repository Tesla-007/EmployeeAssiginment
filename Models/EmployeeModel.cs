using Employee.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployeeAssiginment.Models
{
    public class EmployeeModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Department { get; set; }


        public Emp BindModel()
        {
            Emp emp = new();
            emp.FirstName = FirstName;
            emp.LastName = LastName;
            emp.Department = Department;
            emp.Role = Role;
            emp.CreatedAt = DateTime.Now;
            return emp;
        }
    }
}
