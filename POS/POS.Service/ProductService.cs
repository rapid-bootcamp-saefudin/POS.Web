using POS.Repository;
using Microsoft.AspNetCore.Mvc;
using POS.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace POS.Service
{
    public class ProductService
    {
        private readonly ApplicationDbContext _context;
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        private ProductModel EntityToModel(ProductEntity entity)
        {
            ProductModel result = new ProductModel();
            result.Id = entity.Id;
            result.ProductName = entity.ProductName;
            result.SupplierId = entity.SupplierId;
            result.CategoryId = entity.CategoryId;
            result.QuantityPerUnit = entity.QuantityPerUnit;
            result.UnitPrice = entity.UnitPrice;
            result.UnitsInStock = entity.UnitsInStock;
            result.UnitsOnOrder = entity.UnitsOnOrder;
            result.ReorderLevel = entity.ReorderLevel;
            result.Discontinued = entity.Discontinued;
            return result;
        }

        private void ModelToEntity(ProductModel model, ProductEntity entity)
        {
            entity.ProductName = model.ProductName;
            entity.SupplierId = model.SupplierId;
            entity.CategoryId = model.CategoryId;
            entity.QuantityPerUnit = model.QuantityPerUnit;
            entity.UnitPrice = model.UnitPrice;
            entity.UnitsInStock = model.UnitsInStock;
            entity.UnitsOnOrder = model.UnitsOnOrder;
            entity.ReorderLevel = model.ReorderLevel;
            entity.Discontinued = model.Discontinued;
        }

        public List<ProductEntity> GetProducts()
        {
            return _context.Products.ToList();
        }

        public void SaveProduct(ProductModel request)
        {
            var entity = new ProductEntity();
            ModelToEntity(request, entity); 
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public ProductModel GetProductById(int id)
        {
            var product = _context.Products.Find(id);
            return EntityToModel(product);
        }

        public void UpdateProduct(ProductModel request)
        {
            var entity = _context.Products.Find(request.Id);
            ModelToEntity(request, entity);
            _context.Products.Update(entity);
            _context.SaveChanges();
        }

        public void DeleteProductById(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
