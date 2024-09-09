using FinalProject.BLL.Interfacies;
using FinalProject.BLL.Repositories;
using FinalProject.DAL.Data;
using FinalProject.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.PL.Controllers
{
    public class DepartmentController : Controller
    {
      
         private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository repository)
        {
            _departmentRepository = repository;

            //_departmentRepository = new DepartmentRepository(new AppDbContext(new AppDbContextOption())
            // _departmentRepository = repository;
        }

       

        public IActionResult Index()
        {
          var departments  =   _departmentRepository.GetAll();
            return View();
        }
    }
}
