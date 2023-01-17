using POS.Repository;
using Microsoft.AspNetCore.Mvc;
using POS.ViewModel;

namespace POS.Service
{
    public class SupplierService
    {
        private readonly ApplicationDbContext _context;
        public SupplierService(ApplicationDbContext context)
        {
            _context = context;
        }

        private SupplierModel EntityToModel(SupplierEntity entity)
        {
            SupplierModel result = new SupplierModel();
            result.Id = entity.Id;
            result.CompanyName= entity.CompanyName;
            result.ContactName = entity.ContactName;
            result.ContactTitle = entity.ContactTitle;
            result.Address = entity.Address;
            result.City = entity.City;
            result.Region = entity.Region;
            result.PostalCode = entity.PostalCode;
            result.Country = entity.Country;
            result.Phone = entity.Phone;
            result.Fax = entity.Fax;
            result.HomePage= entity.HomePage;
            return result;
        }

        private void ModelToEntity(SupplierModel model, SupplierEntity entity)
        {
            entity.CompanyName = model.CompanyName;
            entity.ContactName = model.ContactName;
            entity.ContactTitle = model.ContactTitle;
            entity.Address = model.Address;
            entity.City = model.City;
            entity.Region = model.Region;
            entity.PostalCode = model.PostalCode;
            entity.Country = model.Country;
            entity.Phone = model.Phone;
            entity.Fax = model.Fax;
            entity.HomePage = model.HomePage;
        }

        public List<SupplierEntity> GetSuppliers()
        {
            return _context.Suppliers.ToList();
        }

        public void AddSupplier(SupplierEntity request)
        {
            _context.Suppliers.Add(request);
            _context.SaveChanges();
        }

        public SupplierModel GetSupplierById(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            return EntityToModel(supplier);
        }

        public void UpdateSupplier(SupplierModel supplier)
        {
            var entity = _context.Suppliers.Find(supplier.Id);
            ModelToEntity(supplier, entity);
            _context.Suppliers.Update(entity);
            _context.SaveChanges();
        }

        public void DeleteSupplierById(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();
        }
    }
}
