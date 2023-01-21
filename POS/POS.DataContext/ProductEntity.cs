using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
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
        public int SupplierId { get; set; }
        public SupplierEntity Supplier { get; set; }
        [Column("category_id")]
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        [Column("quantity_per_unit")]
        public int QuantityPerUnit { get; set; }
        [Column("unit_price")]
        public double UnitPrice { get; set; }
        [Column("units_in_stock")]
        public int UnitsInStock { get; set; }
        [Column("units_on_order")]
        public int UnitsOnOrder { get; set; }
        [Column("reorder_level")]
        public int ReorderLevel { get; set; }
        [Column("discontinued")]
        public bool Discontinued { get; set; }

        //
        public ICollection<OrderDetailEntity> OrderDetails { get; set; }

        //
        //public ProductEntity() { }
        //public ProductEntity(POS.ViewModel.ProductModel vmodel)
        //{
        //    ProductName = vmodel.ProductName;
        //    SupplierId = vmodel.SupplierId;
        //    CategoryId = vmodel.CategoryId;
        //    QuantityPerUnit = vmodel.QuantityPerUnit;
        //    UnitPrice = vmodel.UnitPrice;
        //    UnitsInStock = vmodel.UnitsInStock;
        //    UnitsOnOrder = vmodel.UnitsOnOrder;
        //    ReorderLevel = vmodel.ReorderLevel;
        //    Discontinued = vmodel.Discontinued;
        //}
    }
}
