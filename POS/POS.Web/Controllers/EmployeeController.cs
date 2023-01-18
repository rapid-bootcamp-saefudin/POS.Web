using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _service;
        public EmployeeController(ApplicationDbContext context)
        {
            _service = new EmployeeService(context);
        }


        // GET: EmployeeController
        [HttpGet]
        public IActionResult Index()
        {
            var Data = _service.GetEmployees();
            return View(Data);
        }

        // GET: EmployeeController/Details/5
        [HttpGet]
        public IActionResult Details(int id)
        {
            var employee = _service.GetEmployeeById(id);
            return View(employee);
        }

        // GET: EmployeeController/Create
        [HttpGet]
        public IActionResult AddModal()
        {
            return PartialView("Create");
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath")]EmployeeModel request)
        {
            if (ModelState.IsValid)
            {
                _service.SaveEmployee(new EmployeeEntity(request));
                return Redirect("Index");
            }
            return View("Create", request);
        }

        // GET: EmployeeController/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _service.GetEmployeeById(id);
            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("Id, LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath")] EmployeeModel request)
        {
            if (ModelState.IsValid)
            {
                //EmployeeEntity catEntity = new EmployeeEntity(request);
                //catEntity.Id = request.Id;

                _service.UpdateEmployee(request);
                //return Redirect("Index");
                return Redirect("Index");
            }
            return View("Edit", request);
        }

        // GET: EmployeeController/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _service.DeleteEmployeeById(id);
            return RedirectToAction("Index");
        }
    }
}
