using POS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace POS.Service
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ProductEntity> GetProducts()
        {
            return _context.Products.ToList();
        }

        public ProductEntity GetProductById(int id)
        {
            return _context.Products.Find(id);
        }

        public List<ProductEntity> SaveProduct([Bind("ProductName, SupplierId, CategoryId, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued")] ProductEntity product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return GetProducts();
        }

        public List<ProductEntity> UpdateProduct([Bind("Id, ProductName, SupplierId, CategoryId, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued")] ProductEntity product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
            return GetProducts();
        }

        public List<ProductEntity> DeleteProductById(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return GetProducts();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return GetProducts();
        }
    }
}
