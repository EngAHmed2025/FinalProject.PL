using FinalProject.BLL.Interfacies;
using FinalProject.DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;

namespace FinalProject.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IWebHostEnvironment _env;

        public EmployeeController(IEmployeeRepository repository, IWebHostEnvironment env)
        {
            _EmployeeRepository = repository;
            _env = env;

            //_EmployeeRepository = new EmployeeRepository(new AppDbContext(new AppDbContextOption())
            // _EmployeeRepository = repository;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var Employees = _EmployeeRepository.GetAll();
            return View(Employees);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee Employee)
        {
            if (ModelState.IsValid)
            {
                var Count = _EmployeeRepository.Add(Employee);

                if (Count > 0)
                {

                    return RedirectToAction(nameof(Index));
                }


            }
            return View(Employee);
        }

        [HttpGet]
        public IActionResult Details(int? id, string viewName = "Details")
        {

            if (!id.HasValue)
            {
                return BadRequest();
            }

            var Employee = _EmployeeRepository.GetById(id.Value);
            if (Employee == null)
            {

                return NotFound();


            }
            return View(viewName, Employee);
        }

        [HttpGet]

        public IActionResult Edit(int? id)
        {

            //if (!id.HasValue)
            //{
            //    return BadRequest();

            //}


            //var Employee = _EmployeeRepository.GetById(id.Value);
            //if (Employee == null)
            //{
            //    return NotFound();
            //}

            return Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Employee Employee)
        {
            if (id != Employee.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(Employee);


            try
            {

                _EmployeeRepository.Update(Employee);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

                else
                {
                    ModelState.AddModelError(string.Empty, "An Error occured during update Employee");
                }

                return View(Employee);


            }

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employee Employee)
        {

            try
            {
                _EmployeeRepository.Delete(Employee);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

                else
                {
                    ModelState.AddModelError(string.Empty, "An Error occured during update Employee");
                }

                return View(Employee);
            }


        }
    }
}
