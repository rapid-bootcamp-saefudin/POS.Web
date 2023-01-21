using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.ViewModel.Response
{
    public class ProductResponse
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ContactName { get; set; }
        public string CategoryName { get; set; }
        public int QuantityPerUnit { get; set; }
        public double UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
    }
}
