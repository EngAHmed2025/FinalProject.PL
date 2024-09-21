using FinalProject.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.Interfacies
{
    public interface IEmployeeRepository : IGenericRepositroy<Employee>
    {
        IQueryable<Employee>GetEmployeeByAddress(string address);
        IQueryable<Employee> GetEmployeeByName(string name);
    }
}
