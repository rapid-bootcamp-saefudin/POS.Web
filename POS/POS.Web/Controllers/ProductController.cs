using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _service;
        public ProductController(ApplicationDbContext context)
        {
            _service = new ProductService(context);
        }

        // GET: ProductController
        [HttpGet]
        public IActionResult Index()
        {
            var Data = _service.GetProducts();
            return View(Data);
        }

        // GET: ProductController/Details/5
        [HttpGet]
        public IActionResult Details(int id)
        {
            var CatDetail = _service.GetProductById(id);
            return View(CatDetail);
        }

        // GET: ProductController/Create
        [HttpGet]
        public IActionResult AddModal()
        {
            return PartialView("Create");
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ProductName, SupplierId, CategoryId, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued")] ProductModel request)
        {
            if (ModelState.IsValid)
            {
                _service.SaveProduct(request);
                return Redirect("Index");
            }
            return View("Create", request);
        }

        // GET: ProductController/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var CatEdit = _service.GetProductById(id);
            return View(CatEdit);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("Id, ProductName, SupplierId, CategoryId, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued")] ProductModel request)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateProduct(request);
                return Redirect("Index");
            }
            return View("Edit", request);
        }

        // GET: ProductController/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _service.DeleteProductById(id);
            return RedirectToAction("Index");
        }
    }
}
