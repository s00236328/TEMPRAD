using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad301_2024_Week1_Lab1
{
     class Supplier
    {
        public int SupplierID {  get; set; }
        public string SupplierName {  get; set; }
        public string SupplierAddress {  get; set; }
        public string SupplierAddress2 { get; set;}
        public  Supplier() { }

        public Supplier(int id, string name, string addressLine1, string addressLine2)
        {
            SupplierID = id;
            SupplierName = name;
            SupplierAddress = addressLine1;
            SupplierAddress2 = addressLine2;
        }
    }
}
