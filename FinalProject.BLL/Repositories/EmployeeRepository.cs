using FinalProject.BLL.Interfacies;
using FinalProject.DAL.Data;
using FinalProject.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.Repositories
{
    public class EmployeeRepository : GenericRepositroy<Employee> , IEmployeeRepository
    {
        private readonly AppDbContext _dbContext;
        public EmployeeRepository(AppDbContext dbContext):base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public IQueryable<Employee> GetEmployeeByAddress(string address)
        {
            return _dbContext.Employees.Where(E => E.Address.ToLower().Contains(address.ToLower()));
                }

        public IQueryable<Employee> GetEmployeeByName(string name)
        {
           return _dbContext.Employees.Where(E =>E.Name.ToLower().Contains(name));
        }
    }
}
    
