﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Models
{
    public enum Gender
    {
        [EnumMember(Value ="Male")]
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
    
        [Required(ErrorMessage ="Name Is Required!")]
        [MaxLength(50,ErrorMessage ="Max Length For Name is 50")]
        [MinLength(4,ErrorMessage ="Min Length For Name is 4")]

        public string Name { get; set; }
        [Range(21,60)]
        public int? Age { get; set; }
        [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}$", ErrorMessage ="Address Must be like 123-street-city-country")
         ]
        public string  Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public bool ISActive { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [RegularExpression(@"^\+?\d{0,13}$", ErrorMessage = "Not a valid phone number.")]
        [Display(Name = "Phone Number")]
        public int PhoneNumber { get; set; }
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        public bool IsDeleted { get; set; }

        public Gender Gender { get; set; }

    }
}
