using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POS.Repository;
using POS.Service;
using POS.ViewModel;

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
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult AddModal()
        {
            return PartialView("_Create");
        }

        // POST: CategoryController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(CategoryEntity request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _service.SaveCategory(request);
        //    }
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CategoryName, Description, Picture")] CategoryModel request)
        {
            if (ModelState.IsValid)
            {
                _service.AddCategory(new CategoryEntity(request));
                return Redirect("Index");
            }
            return View("Create", request);
        }

        // GET: CategoryController/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var CatEdit = _service.GetCategoryById(id);
            return View(CatEdit);
        }

        // POST: CategoryController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Update(CategoryEntity request)
        //{
        //    _service.UpdateCategory(request);
        //    //return Redirect("Index");
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("Id, CategoryName, Description, Picture")] CategoryModel request)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateCategory(request);
                return Redirect("Index");
            }
            return View("Edit", request);
        }
        //public IActionResult Update(CategoryModel request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        CategoryEntity catEntity = new CategoryEntity(request);
        //        catEntity.Id = request.Id;

        //        _service.UpdateCategory(catEntity);
        //        //return Redirect("Index");
        //        return RedirectToAction("Index");
        //    }
        //    return View("Edit", request);
        //}

        // GET: CategoryController/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _service.DeleteCategoryById(id);
            return RedirectToAction("Index");
        }
    }
}
