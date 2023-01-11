using POS.Repository;

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

        public CategoryEntity GetCategory(int id)
        {
            return _context.Categories.SingleOrDefault();
        }


    }
}