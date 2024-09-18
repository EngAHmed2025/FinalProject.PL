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
    public class DepartmentRepository : GenericRepositroy<Department> , IDepartmentRepository
    {
        private readonly AppDbContext _dbContext;
        public DepartmentRepository(AppDbContext dbContext) :base(dbContext)
        {
            _dbContext = dbContext;
        }
       
    }
}
