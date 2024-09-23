using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad301_2024_Week1_Lab1
{
    class SupplierProduct
    {
        public int SupplierID { get; set; }
        public int ProductID { get; set; }
        public DateTime DateFirstSupplied { get; set; }
        public SupplierProduct() { }

        public SupplierProduct(Supplier sup, Product product, DateTime date)
        {
            SupplierID = sup.SupplierID;
            ProductID = product.ProductID;
            DateFirstSupplied = date;
        }
    }
}
