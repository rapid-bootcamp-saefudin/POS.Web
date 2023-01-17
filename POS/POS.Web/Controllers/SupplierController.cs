using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class SupplierController : Controller
    {
        private readonly SupplierService _service;
        public SupplierController(ApplicationDbContext context)
        {
            _service = new SupplierService(context);
        }

        // GET: SupplierController
        [HttpGet]
        public IActionResult Index()
        {
            var Data = _service.GetSuppliers();
            return View(Data);
        }

        // GET: SupplierController/Details/5
        [HttpGet]
        public IActionResult Details(int id)
        {
            var CatDetail = _service.GetSupplierById(id);
            return View(CatDetail);
        }

        // GET: SupplierController/Create
        [HttpGet]
        public IActionResult AddModal()
        {
            return PartialView("Create");
        }

        // POST: SupplierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, HomePage")] SupplierModel request)
        {
            if (ModelState.IsValid)
            {
                _service.AddSupplier(new SupplierEntity(request));
                return Redirect("Index");
            }
            return View("Create", request);
        }

        // GET: SupplierController/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var CatEdit = _service.GetSupplierById(id);
            return View(CatEdit);
        }

        // POST: SupplierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("Id, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, HomePage")] SupplierModel request)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateSupplier(request);
                return Redirect("Index");
            }
            return View("Edit", request);
        }

        // GET: SupplierController/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _service.DeleteSupplierById(id);
            return RedirectToAction("Index");
        }
    }
}
