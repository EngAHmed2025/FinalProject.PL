using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Models
{
    public enum Gender
    {
        [EnumMember(Value = "Male")]
        Male = 1,
        [EnumMember(Value = "Female")]
        Female = 2
    }

    enum EmployeeType
    {
        [EnumMember(Value = "FullTime")]
        FullTime = 1,
        [EnumMember(Value = "PartTime")]
        PartTime = 2
    }

    public class Employee :ModelBase
    {


       
        public string Name { get; set; }
        
        public int? Age { get; set; }
      
        public string  Address { get; set; }

        public decimal Salary { get; set; }

        public bool ISActive { get; set; }
     
        public string Email { get; set; }
       
        public int PhoneNumber { get; set; }
    
        public DateTime HireDate { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;

        public Gender Gender { get; set; }

       // [InverseProperty(nameof(Models.Department.Employees))]
        public Department Department { get; set; }

        public int? DepartmentId { get; set; }

        public string ImageName { get; set; }
    }
}
