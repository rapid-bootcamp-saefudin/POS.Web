using POS.Repository;
using Microsoft.AspNetCore.Mvc;
using POS.ViewModel;

namespace POS.Service
{
    public class CustomerService
    {
        private readonly ApplicationDbContext _context;
        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        private CustomerModel EntityToModel(CustomerEntity entity)
        {
            CustomerModel result = new CustomerModel();
            result.Id = entity.Id;
            result.CompanyName = entity.CompanyName;
            result.ContactName = entity.ContactName;
            result.ContactTitle = entity.ContactTitle;
            result.Address = entity.Address;
            result.City = entity.City;
            result.Region = entity.Region;
            result.PostalCode = entity.PostalCode;
            result.Country = entity.Country;
            result.Phone = entity.Phone;
            result.Fax = entity.Fax;
            return result;
        }

        private void ModelToEntity(CustomerModel model, CustomerEntity entity)
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
        }

        public List<CustomerEntity> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public void AddCustomer(CustomerEntity request)
        {
            _context.Customers.Add(request);
            _context.SaveChanges();
        }

        public CustomerModel GetCustomerById(int id)
        {
            var customer = _context.Customers.Find(id);
            return EntityToModel(customer);
        }

        public void UpdateCustomer(CustomerModel Customer)
        {
            var entity = _context.Customers.Find(Customer.Id);
            ModelToEntity(Customer, entity);
            _context.Customers.Update(entity);
            _context.SaveChanges();
        }

        public void DeleteCustomerById(int id)
        {
            var customer = _context.Customers.Find(id);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
