using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad301_2024_Week1_Lab1
{
     class Product
    {
        public int ProductID {  get; set; }
        public string Description {  get; set; }
        public int QuantityInStock {  get; set; }
        public float UnitPrice { get; set; }
        public int CategoryID {  get; set; }
        public Product() { }

        public Product(int id, string description, int stock, float price, Category cat)
        {
            ProductID = id;
            Description = description;
            QuantityInStock = stock;
            UnitPrice = price;
            CategoryID = cat.CategoryID;
        }
        
    }
}
