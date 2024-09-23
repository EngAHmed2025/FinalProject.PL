using FinalProject.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Data.Configurations
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(E => E.Salary)
                .HasColumnType("decimal(18,2)");
            builder.Property(E => E.Gender)
                .HasConversion(
                (Gender)=> Gender.ToString(),
                (genderAsString)=> (Gender)Enum.Parse(typeof(Gender), genderAsString,true)
                    );
          
            
        }
    }
}
