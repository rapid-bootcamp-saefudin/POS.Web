using System.ComponentModel.DataAnnotations;

namespace POS.ViewModel
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int SupplierId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int QuantityPerUnit { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        [Required]
        public int UnitsInStock { get; set; }
        [Required]
        public int UnitsOnOrder { get; set; }
        [Required]
        public int ReorderLevel { get; set; }
        [Required]
        public bool Discontinued { get; set; }
    }
}