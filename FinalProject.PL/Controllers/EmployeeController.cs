using AutoMapper;
using FinalProject.BLL.Interfacies;
using FinalProject.DAL.Models;
using FinalProject.PL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections;
using System.Collections.Generic;

namespace FinalProject.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;

        public EmployeeController(IEmployeeRepository repository, IWebHostEnvironment env /*,IDepartmentRepository departmentRepository*/,IMapper mapper)
        {
            _EmployeeRepository = repository;
            _env = env;
            _mapper = mapper;
            // _departmentRepository = departmentRepository;

            //_EmployeeRepository = new EmployeeRepository(new AppDbContext(new AppDbContextOption())
            // _EmployeeRepository = repository;
        }


        //[HttpGet]
        public IActionResult Index(string searchInp)
        {
            if (string.IsNullOrEmpty(searchInp))
            {
                var Employees = _EmployeeRepository.GetAll();
                var MappedEmp = _mapper.Map<IEnumerable<Employee> , IEnumerable<EmployeeViewModel> > (Employees);

                return View(MappedEmp);
            }
            else
            {
              
                var Employees = _EmployeeRepository.GetEmployeeByName(searchInp.ToLower());
                var MappedEmp = _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(Employees);
                return View(MappedEmp);
            }
          
        }
        [HttpGet]
        public IActionResult Create()
        {
            //ViewBag.Department = _departmentRepository.GetAll();    
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeViewModel EmployeeView)
        {
            if (ModelState.IsValid)
            {
                //var MappedEmployee = new Employee()
                //{
                //    Name = EmployeeView.Name,
                //    Age = EmployeeView.Age,
                //    Address = EmployeeView.Address,
                //    Salary = EmployeeView.Salary,
                //    Email = EmployeeView.Email,
                //    PhoneNumber = EmployeeView.PhoneNumber,
                //    IsDeleted = EmployeeView.IsDeleted,
                //    ISActive = EmployeeView.ISActive,
                //};
                var MappedEmp = _mapper.Map<EmployeeViewModel ,Employee>(EmployeeView);
                var Count = _EmployeeRepository.Add(MappedEmp);

                if (Count > 0)
                {

                    return RedirectToAction(nameof(Index));
                }


            }
            return View(EmployeeView);
        }

        [HttpGet]
        public IActionResult Details(int? id, string viewName = "Details")
        {

            if (!id.HasValue)
            {
                return BadRequest();
            }

            var Employee = _EmployeeRepository.GetById(id.Value);
           // ViewBag.Department = _departmentRepository.GetAll();
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
        public IActionResult Edit([FromRoute] int id, EmployeeViewModel EmployeeView)
        {
            if (id != EmployeeView.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(EmployeeView);


            try
            {
                var MappedEmp = _mapper.Map<EmployeeViewModel, Employee>(EmployeeView);
                _EmployeeRepository.Update(MappedEmp);
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

                return View(EmployeeView);


            }

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(EmployeeViewModel EmployeeView)
        {

            try
            {
                var MappedEmp = _mapper.Map<EmployeeViewModel, Employee>(EmployeeView);
                _EmployeeRepository.Delete(MappedEmp);
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

                return View(EmployeeView);
            }


        }
    }
}
