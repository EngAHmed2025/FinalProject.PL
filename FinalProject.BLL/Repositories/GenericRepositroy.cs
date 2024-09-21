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
    public class GenericRepositroy<T> : IGenericRepositroy<T> where T : ModelBase
    {
        private readonly AppDbContext _dbContext;
        public GenericRepositroy(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(T item)
        {
            _dbContext.Set<T>().Add(item);
            return _dbContext.SaveChanges();
        }

        public int Delete(T item)
        {
            _dbContext.Set<T>().Remove(item);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            if(typeof(T) == typeof(Employee)){
              return (IEnumerable<T>) _dbContext.Employees.Include(E => E.Department).AsNoTracking().ToList();
            }
            else
            {
                return _dbContext.Set<T>().AsNoTracking().ToList();
            }
            
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);

        }

        public int Update(T item)
        {
            _dbContext.Set<T>().Update(item);
            return _dbContext.SaveChanges();
        }
    }
}
