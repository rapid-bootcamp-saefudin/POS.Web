using POS.ViewModel;
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
    [Table("tbl_shippers")]                   
    public class ShipperEntity
    {
        [Key]                                                   
        [Column("id")]
        public int Id { get; set; }
        [Column("company_name")]
        public string CompanyName { get; set; }
        [Column("phone")]
        public string Phone { get; set; }

        //
        public ICollection<OrderEntity> Orders { get; set; }

        //
        public ShipperEntity() { }
        public ShipperEntity(ShipperModel vmodel)
        {
            CompanyName = vmodel.CompanyName;
            Phone = vmodel.Phone;
        }
    }
}
