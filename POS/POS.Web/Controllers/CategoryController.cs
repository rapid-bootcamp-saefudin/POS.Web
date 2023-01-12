using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.Service;

namespace POS.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _service;
        public CategoryController(ApplicationDbContext context)
        {
            _service = new CategoryService(context);
        }


        // GET: CategoryController
        [HttpGet]
        public IActionResult Index()
        {
            var Data = _service.GetCategories();
            return View(Data);
        }

        // GET: CategoryController/Details/5
        [HttpGet]
        public IActionResult Details(int id)
        {
            var CatDetail = _service.GetCategoryById(id);
            return View(CatDetail);
        }

        // GET: CategoryController/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        public IActionResult Create(CategoryEntity request)
        {
            _service.SaveCategory(request);
            return RedirectToAction("Index");
        }

        // GET: CategoryController/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var CatEdit = _service.GetCategoryById(id);
            return View(CatEdit);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        public IActionResult Update(CategoryEntity request)
        {
            _service.UpdateCategory(request);
            //return Redirect("Index");
            return RedirectToAction("Index");
        }

        // GET: CategoryController/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _service.DeleteCategoryById(id);
            return RedirectToAction("Index");
        }
    }
}
