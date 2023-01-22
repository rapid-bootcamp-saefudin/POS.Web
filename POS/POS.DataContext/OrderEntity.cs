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
    [Table("tbl_orders")]
    public class OrderEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("customer_id")]
        public int CustomerId { get; set; }
        public CustomerEntity Customer { get; set; }

        [Column("employee_id")]
        public int EmployeeId { get; set; }
        public EmployeeEntity Employee { get; set; }

        [Column("order_date")]
        public DateOnly OrderDate { get; set; }
        [Column("required_date")]
        public DateOnly RequiredDate { get; set; }
        [Column("shipped_date")]
        public DateOnly ShippedDate { get; set; }



        // shipper_id?
        [Column("ship_id")]
        public int ShipperId { get; set; }
        public ShipperEntity Shipper { get; set; }

        [Column("freight")]
        public string Freight { get; set; }
        [Column("ship_name")]
        public string ShipName { get; set; }
        [Column("ship_address")]
        public string ShipAddress { get; set; }
        [Column("ship_city")]
        public string ShipCity { get; set; }
        [Column("ship_region")]
        public string ShipRegion { get; set; }
        [Column("ship_postal_code")]
        public string ShipPostalCode { get; set; }
        [Column("ship_country")]
        public string ShipCountry { get; set; }

        //
        public List<OrderDetailEntity> OrderDetails { get; set; }

        //
        public OrderEntity() { }
    }
}
