using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _context;
        public EmployeeService(ApplicationDbContext context) 
        {
            _context = context;
        }

        private EmployeeModel EntityToModel(EmployeeEntity entity)
        {
            EmployeeModel result = new EmployeeModel();
            result.Id = entity.Id;
            result.LastName = entity.LastName;
            result.FirstName = entity.FirstName;
            result.Title = entity.Title;
            result.TitleOfCourtesy = entity.TitleOfCourtesy;
            result.BirthDate = entity.BirthDate;
            result.HireDate = entity.HireDate;
            result.Address = entity.Address;
            result.City = entity.City;
            result.Region = entity.Region;
            result.PostalCode = entity.PostalCode;
            result.Country = entity.Country;
            result.HomePhone = entity.HomePhone;
            result.Extension = entity.Extension;
            result.Photo = entity.Photo;
            result.Notes = entity.Notes;
            result.ReportsTo = entity.ReportsTo;
            result.PhotoPath = entity.PhotoPath;
            return result;
        }

        private void ModelToEntity(EmployeeModel model, EmployeeEntity entity)
        {
            entity.LastName = model.LastName;
            entity.FirstName = model.FirstName;
            entity.Title = model.Title;
            entity.TitleOfCourtesy = model.TitleOfCourtesy;
            entity.BirthDate = model.BirthDate;
            entity.HireDate = model.HireDate;
            entity.Address = model.Address;
            entity.City = model.City;
            entity.Region = model.Region;
            entity.PostalCode = model.PostalCode;
            entity.Country = model.Country;
            entity.HomePhone = model.HomePhone;
            entity.Extension = model.Extension;
            entity.Photo = model.Photo;
            entity.Notes = model.Notes;
            entity.ReportsTo = model.ReportsTo;
            entity.PhotoPath = model.PhotoPath;
        }

        public List<EmployeeEntity> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        public EmployeeModel GetEmployeeById(int id)
        {
            var employee = _context.Employees.Find(id);
            return EntityToModel(employee);
        }

        //public EmployeeEntity GetEmployeeById(int id)
        //{
        //    return _context.Employees.Find(id);
        //}

        //public List<EmployeeEntity> SaveEmployee([Bind("LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath")]EmployeeEntity employee)
        //{
        //    _context.Employees.Add(employee);
        //    _context.SaveChanges();
        //    return GetEmployees();
        //}

        //public void SaveEmployee(EmployeeModel request)
        //{
        //    var entity = new EmployeeEntity();
        //    ModelToEntity(request, entity);
        //    _context.Employees.Add(entity);
        //    _context.SaveChanges();
        //}

        public void SaveEmployee(EmployeeEntity request)
        {
            _context.Employees.Add(request);
            _context.SaveChanges();
        }

        public void UpdateEmployee(EmployeeModel request)
        {
            var entity = _context.Employees.Find(request.Id);
            ModelToEntity(request, entity);
            _context.Employees.Update(entity);
            _context.SaveChanges();
        }

        public void DeleteEmployeeById(int id)
        {
            var employee = _context.Employees.Find(id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }
    }
}
