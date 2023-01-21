using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.ViewModel
{
    public class OrderModel
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public DateOnly OrderDate { get; set; }
        [Required]
        public DateOnly RequiredDate { get; set; }
        [Required]
        public DateOnly ShippedDate { get; set; }
        [Required]
        public int ShipperId { get; set; }
        [Required]
        public string Freight { get; set; }
        [Required]
        public string ShipName { get; set; }
        [Required]
        public string ShipAddress { get; set; }
        [Required]
        public string ShipCity { get; set; }
        [Required]
        public string ShipRegion { get; set; }
        [Required]
        public string ShipPostalCode { get; set; }
        [Required]
        public string ShipCountry { get; set; }
        public List<OrderDetailModel> OrderDetails { get; set; }
    }
}