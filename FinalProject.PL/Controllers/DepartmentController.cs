using FinalProject.BLL.Interfacies;
using FinalProject.BLL.Repositories;
using FinalProject.DAL.Data;
using FinalProject.DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;

namespace FinalProject.PL.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly IDepartmentRepository _departmentRepository;
        private readonly IWebHostEnvironment _env;

        public DepartmentController(IDepartmentRepository repository ,IWebHostEnvironment env)
        {
            _departmentRepository = repository;
            _env = env;

            //_departmentRepository = new DepartmentRepository(new AppDbContext(new AppDbContextOption())
            // _departmentRepository = repository;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentRepository.GetAll();
            return View(departments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                var Count = _departmentRepository.Add(department);

                if (Count > 0)
                {

                    return RedirectToAction(nameof(Index));
                }


            }
            return View(department);
        }

        [HttpGet]
        public IActionResult Details(int? id , string viewName="Details")
        {

            if (!id.HasValue)
            {
                return BadRequest();
            }

            var department = _departmentRepository.GetById(id.Value);
            if (department == null)
            {

                return NotFound();


            }
            return View(viewName,department);
        }

        [HttpGet]
        
        public IActionResult Edit(int? id)
        {

            //if (!id.HasValue)
            //{
            //    return BadRequest();

            //}


            //var department = _departmentRepository.GetById(id.Value);
            //if (department == null)
            //{
            //    return NotFound();
            //}

            return Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int id, Department department)
        {
            if (id != department.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(department);


            try
            {

                _departmentRepository.Update(department);
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
                    ModelState.AddModelError(string.Empty, "An Error occured during update department");
                }

                return View(department);


            }

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Department department)
        {

            try
            {
               _departmentRepository.Delete(department);
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
                    ModelState.AddModelError(string.Empty, "An Error occured during update department");
                }

                return View(department);
            }

        
        }
    }
}
