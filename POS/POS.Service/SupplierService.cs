using POS.Repository;
using Microsoft.AspNetCore.Mvc;

namespace POS.Service
{
    public class SupplierService
    {
        private readonly ApplicationDbContext _context;
        public SupplierService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<SupplierEntity> GetSuppliers()
        {
            return _context.Suppliers.ToList();
        }

        public SupplierEntity GetSupplierById(int id)
        {
            return _context.Suppliers.Find(id);
        }

        public List<SupplierEntity> SaveSupplier([Bind("CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, HomePage")] SupplierEntity supplier)
        {
            _context.Suppliers.Add(supplier);
            _context.SaveChanges();
            return GetSuppliers();
        }

        public List<SupplierEntity> UpdateSupplier([Bind("Id, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, HomePage")] SupplierEntity supplier)
        {
            _context.Suppliers.Update(supplier);
            _context.SaveChanges();
            return GetSuppliers();
        }

        public List<SupplierEntity> DeleteSupplierById(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier == null)
            {
                return GetSuppliers();
            }
            _context.Suppliers.Remove(supplier);
            _context.SaveChanges();
            return GetSuppliers();
        }
    }
}
