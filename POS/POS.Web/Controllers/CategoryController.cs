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

            //try
            //{
            //    _service.Save(request);
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View(Index);
            //}
        }

        // GET: CategoryController/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        public IActionResult Update(CategoryEntity request)
        {
            _service.UpdateCategory(request);
            return RedirectToAction("Index");

            //try
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: CategoryController/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
