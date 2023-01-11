using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_products")]
    public class ProductEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("product_name")]
        public string ProductName { get; set; }
        [Column("supplier_id")]
        public SupplierEntity Suppliers { get; set; }
        [Column("category_id")]
        public CategoryEntity Categorys { get; set; }
        [Column("quantity_per_unit")]
        public int QuantityPerUnit { get; set; }
        [Column("unit_price")]
        public double UnitPrice { get; set; }
        [Column("units_in_stock")]
        public int UnitsInStock { get; set; }
        [Column("units_on_order")]
        public int UnitsOnOrder { get; set; }
        [Column("reorder_level")]
        public bool ReorderLevel { get; set; }
        [Column("discontinued")]
        public bool Discontinued { get; set; }

        //
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
