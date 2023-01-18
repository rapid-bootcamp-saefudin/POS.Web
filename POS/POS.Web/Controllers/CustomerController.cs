using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerService _service;
        public CustomerController(ApplicationDbContext context)
        {
            _service = new CustomerService(context);
        }

        // GET: CustomerController
        [HttpGet]
        public IActionResult Index()
        {
            var Data = _service.GetCustomers();
            return View(Data);
        }

        // GET: CustomerController/Details/5
        [HttpGet]
        public IActionResult Details(int id)
        {
            var custDetail = _service.GetCustomerById(id);
            return View(custDetail);
        }

        // GET: CustomerController/Create
        [HttpGet]
        public IActionResult AddModal()
        {
            return PartialView("Create");
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax")] CustomerModel request)
        {
            if (ModelState.IsValid)
            {
                _service.AddCustomer(new CustomerEntity(request));
                return Redirect("Index");
            }
            return View("Create", request);
        }

        // GET: CustomerController/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var custEdit = _service.GetCustomerById(id);
            return View(custEdit);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("Id, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax")] CustomerModel request)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateCustomer(request);
                return Redirect("Index");
            }
            return View("Edit", request);
        }

        // GET: CustomerController/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _service.DeleteCustomerById(id);
            return RedirectToAction("Index");
        }
    }
}
