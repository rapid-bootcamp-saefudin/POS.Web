using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.ViewModel
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string TitleOfCourtesy { get; set; }
        [Required]
        public DateOnly BirthDate { get; set; }
        [Required]
        public DateOnly HireDate { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string HomePhone { get; set; }
        [Required]
        public string Extension { get; set; }
        [Required]
        public string Photo { get; set; }
        [Required]
        public string Notes { get; set; }
        [Required]
        public string ReportsTo { get; set; }
        [Required]
        public string PhotoPath { get; set; }
    }
}