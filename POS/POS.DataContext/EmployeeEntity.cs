using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_employees")]
    public class EmployeeEntity
    {
        [Key]                                       
        [Column("id")]
        public int Id { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("first_name")]
        public string FirstName { get; set; }
        [Column("title")]
        public string Title { get; set; }
        [Column("title_of_courtesy")]
        public string TitleOfCourtesy { get; set; }
        [Column("birth_date")]
        public DateOnly BirthDate { get; set; }
        [Column("hire_date")]
        public DateOnly HireDate { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("city")]
        public string City { get; set; }
        [Column("region")]
        public string Region { get; set; }
        [Column("postal_code")]
        public string PostalCode { get; set; }
        [Column("country")]
        public string Country { get; set; }
        [Column("home_phone")]
        public string HomePhone { get; set; }
        [Column("extension")]
        public string Extension { get; set; }
        [Column("photo")]
        public string Photo { get; set; }
        [Column("notes")]
        public string Notes { get; set; }
        [Column("reports_to")]
        public string ReportsTo { get; set; }
        [Column("photo_path")]
        public string PhotoPath { get; set; }

        //
        public ICollection<OrderEntity> Orders { get; set; }
    }
}
