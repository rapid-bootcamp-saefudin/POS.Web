using POS.Repository;
using Microsoft.AspNetCore.Mvc;
using POS.ViewModel;

namespace POS.Service
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        private CategoryModel EntityToModel(CategoryEntity entity)
        {
            CategoryModel result = new CategoryModel();
            result.Id = entity.Id;
            result.CategoryName = entity.CategoryName;
            result.Description = entity.Description;
            result.Picture = entity.Picture;
            return result;
        }

        private void ModelToEntity(CategoryModel model, CategoryEntity entity)
        {
            entity.CategoryName = model.CategoryName;
            entity.Description = model.Description;
            entity.Picture = model.Picture;
        }

        public List<CategoryEntity> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public void AddCategory(CategoryEntity request)
        {
            _context.Categories.Add(request);
            _context.SaveChanges();
        }

        public CategoryModel GetCategoryById(int id)
        {
            var category = _context.Categories.Find(id);
            return EntityToModel(category);
        }

        public void DeleteCategoryById(int id)
        {
            var category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(CategoryModel category)
        {
            var entity = _context.Categories.Find(category.Id);
            ModelToEntity(category, entity);
            _context.Categories.Update(entity);
            _context.SaveChanges();
        }

        //public List<CategoryEntity> GetCategories()
        //{
        //    return _context.Categories.ToList();
        //}

        //public CategoryEntity GetCategoryById(int id)
        //{
        //    return _context.Categories.Find(id);
        //}

        //public List<CategoryEntity> SaveCategory([Bind("CategoryName, Description, Picture")] CategoryEntity category)
        //{
        //    _context.Categories.Add(category);
        //    _context.SaveChanges();
        //    return GetCategories();
        //}

        //public List<CategoryEntity> UpdateCategory([Bind("Id, CategoryName, Description, Picture")] CategoryEntity category)
        //{
        //    _context.Categories.Update(category);
        //    _context.SaveChanges();
        //    return GetCategories();
        //}

        //public List<CategoryEntity> DeleteCategoryById(int id)
        //{
        //    var category = _context.Categories.Find(id);
        //    if (category == null) 
        //    {
        //        return GetCategories();
        //    }
        //    _context.Categories.Remove(category);
        //    _context.SaveChanges();
        //    return GetCategories();
        //}
    }
}