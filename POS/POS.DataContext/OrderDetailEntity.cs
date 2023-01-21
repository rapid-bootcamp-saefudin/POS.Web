using POS.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_order_details")]
    public class OrderDetailEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("order_id")]
        public int OrderId { get; set; }
        public OrderEntity Order { get; set; }
        [Column("product_id")]
        public int ProductId { get; set; }
        public ProductEntity Product { get; set; }
        [Column("unit_price")]
        public double UnitPrice { get; set; }
        [Column("quantity")]
        public int Quantity { get; set; }
        [Column("discount")]
        public double Discount { get; set; }

        //
        public OrderDetailEntity() { }
        public OrderDetailEntity(OrderDetailModel vmodel)
        {
            Id = vmodel.Id;
            OrderId = vmodel.OrderId;
            ProductId = vmodel.ProductId;
            UnitPrice = vmodel.UnitPrice;
            Quantity = vmodel.Quantity;
            Discount = vmodel.Discount;
        }
    }
}
