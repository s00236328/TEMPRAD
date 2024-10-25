using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Part1
{
    public class Product
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int QuantityInStock { get; set; }
        public double UnitPrice { get; set; }
        public int CategoryId { get; set; }
    }
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
    public class Supplier
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
    }
    public class SupplierProduct
    {
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public DateTime DateFirstSupplied { get; set; }
    }

}
