using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Models
{
    public class Department
    {
        public int Id { get; set; }//PK Identity (1,1)
        [Required(ErrorMessage = "Code is Required!")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Name is Required!")]
        public string Name { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
