using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

namespace POS.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderService _service;
        private readonly CustomerService _customerService;
        private readonly EmployeeService _employeeService;
        private readonly ShipperService _shipperService;
        private readonly ProductService _productService;

        public OrderController(ApplicationDbContext context)
        {
            _service = new OrderService(context);
            _customerService = new CustomerService(context);
            _employeeService = new EmployeeService(context);
            _shipperService = new ShipperService(context);
            _productService = new ProductService(context);
        }

        // GET: OrderController
        [HttpGet]
        public IActionResult Index()
        {
            var Data = _service.GetOrders();
            return View(Data);
        }

        // GET: OrderController/Details/5
        [HttpGet]
        public IActionResult Details(int? id)
        {
            var orderDetail = _service.ReadOrderInvoice(id);
            return View(orderDetail);
        }

        // GET: OrderController/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Customer = new SelectList(_customerService.GetCustomers(), "Id", "ContactName");
            ViewBag.Employee = new SelectList(_employeeService.GetEmployees(), "Id", "LastName");
            ViewBag.Shipper = new SelectList(_shipperService.GetShippers(), "Id", "CompanyName");
            ViewBag.Product = new SelectList(_productService.GetProducts(), "Id", "ProductName");
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save([Bind("CustomerId, EmployeeId, OrderDate, RequiredDate, ShippedDate, ShipperId, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry, OrderDetails")] OrderModel request)
        {
            if (ModelState.IsValid)
            {
                _service.AddOrder(request);
                return Redirect("Index");
            }
            return View("Create", request);
        }

        // GET: OrderController/Edit/5
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            ViewBag.Customer = new SelectList(_customerService.GetCustomers(), "Id", "ContactName");
            ViewBag.Employee = new SelectList(_employeeService.GetEmployees(), "Id", "LastName");
            ViewBag.Shipper = new SelectList(_shipperService.GetShippers(), "Id", "CompanyName");
            ViewBag.Product = new SelectList(_productService.GetProducts(), "Id", "ProductName");
            var order = _service.GetOrderById(id);
            return View(order);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("Id, CustomerId, EmployeeId, OrderDate, RequiredDate, ShippedDate, ShipperId, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry, OrderDetails")] OrderModel request)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateOrder(request);
                return Redirect("Index");
            }
            return View("Edit", request);
        }

        // GET: OrderController/Delete/5
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            _service.DeleteOrderById(id);
            return RedirectToAction("Index");
        }
    }
}
