using Microsoft.AspNetCore.Mvc;
using POS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<EmployeeEntity> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        public EmployeeEntity GetEmployee(int id)
        {
            return _context.Employees.Find(id);
        }

        public List<EmployeeEntity> SaveEmployee([Bind("LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Photo, Notes, ReportsTo, PhotoPath")]EmployeeEntity employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return GetEmployees();
        }
    }
}
