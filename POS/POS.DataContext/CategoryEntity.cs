using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Repository
{
    [Table("tbl_categories")]
    public class CategoryEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("category_name")]
        public string CategoryName { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("picture")]
        public string Picture { get; set; }

        //
        public ICollection<ProductEntity> Products { get; set; }
    }
}
