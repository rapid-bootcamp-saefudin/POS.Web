using POS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace POS.Service
{
    public class CategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CategoryEntity> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public CategoryEntity GetCategoryById(int id)
        {
            return _context.Categories.Find(id);
        }

        public List<CategoryEntity> SaveCategory([Bind("CategoryName, Description, Picture")] CategoryEntity category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return GetCategories();
        }

        public List<CategoryEntity> UpdateCategory([Bind("Id, CategoryName, Description, Picture")] CategoryEntity category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return GetCategories();
        }

        public List<CategoryEntity> DeleteCategoryById(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) 
            {
                return GetCategories();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return GetCategories();
        }
    }
}