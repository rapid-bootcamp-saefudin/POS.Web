using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class ShipperController : Controller
    {
        private readonly ShipperService _service;
        public ShipperController(ApplicationDbContext context)
        {
            _service = new ShipperService(context);
        }

        // GET: ShipperController
        [HttpGet]
        public IActionResult Index()
        {
            var Data = _service.GetShippers();
            return View(Data);
        }

        // GET: ShipperController/Details/5
        [HttpGet]
        public IActionResult Details(int id)
        {
            var shippDetail = _service.GetShipperById(id);
            return View(shippDetail);
        }

        // GET: ShipperController/Create
        [HttpGet]
        public IActionResult AddModal()
        {
            return PartialView("Create");
        }

        // POST: ShipperController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CompanyName, Phone")] ShipperModel request)
        {
            if (ModelState.IsValid)
            {
                _service.AddShipper(new ShipperEntity(request));
                return Redirect("Index");
            }
            return View("Create", request);
        }

        // GET: ShipperController/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var shippEdit = _service.GetShipperById(id);
            return View(shippEdit);
        }

        // POST: ShipperController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("Id, CompanyName, Phone")] ShipperModel request)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateShipper(request);
                return Redirect("Index");
            }
            return View("Edit", request);
        }

        // GET: ShipperController/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _service.DeleteShipperById(id);
            return RedirectToAction("Index");
        }
    }
}
