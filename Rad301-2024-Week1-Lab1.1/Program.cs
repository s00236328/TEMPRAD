using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad301_2024_Week1_Lab1._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //list categories
            List<Category> categories = new List<Category>
            {
                new Category { CategoryID = 1, Description = "Hardware" },
                new Category { CategoryID = 2, Description = "Electrical Appliances" }
            };
            //list all products
            List<Product> products = new List<Product>
            {
                new Product{ProductID =1,Description= "9 Inch Nails",QuantityInStock= 200, UnitPrice= 0.1f, CategoryID= 1 },
                new Product{ProductID =2,Description= "9 Inch Bolts ",QuantityInStock= 120 , UnitPrice= 0.2f, CategoryID= 1 },
                new Product{ProductID =3,Description= "Chimney Hoover ",QuantityInStock= 10 , UnitPrice= 100.30f, CategoryID= 2 },
                new Product{ProductID =4,Description= "Washing Machine",QuantityInStock= 7, UnitPrice= 399.50f, CategoryID= 2},
            };
            List<Supplier> suppliers = new List<Supplier>
            {
                new Supplier{SupplierID=1,SupplierName="ACME",SupplierAddress="Collooney",SupplierAddress2="Sligo"},
                 new Supplier{SupplierID=2,SupplierName="Swift Electric",SupplierAddress="Finglas",SupplierAddress2="Dublin"},
            };
            List<SupplierProduct> supplierproducts = new List<SupplierProduct>
            {
                new SupplierProduct{SupplierID=1,ProductID=1,DateFirstSupplied=new DateTime(2012, 12, 12)},
                new SupplierProduct{SupplierID=1,ProductID=2,DateFirstSupplied=new DateTime(2017, 08, 13)},
                new SupplierProduct{SupplierID=2,ProductID=3,DateFirstSupplied=new DateTime(2022, 09, 09)},
                new SupplierProduct{SupplierID=2,ProductID=4,DateFirstSupplied=new DateTime(2024, 04, 11)},
            };
            var categoryIds = from category in categories
                              select category.CategoryID;
            Console.WriteLine("Category IDs:");
            foreach (var id in categoryIds)
            {
                Console.WriteLine(id);
            }

            var productIDs = from Product in products
                              select Product.ProductID;
            Console.WriteLine("Product IDs:");
            foreach (var id in productIDs)
            {
                Console.WriteLine(id);
            }
           
            var products100=from Product in products
                            where Product.QuantityInStock<=100
                            select Product.ProductID;
            
            Console.WriteLine("Product IDs with quantity <=100");
            foreach (var id in products100)
            {
                Console.WriteLine(id);
            }

            Console.WriteLine("Product IDs with quantity > 120");
            var products120 = from Product in products
                              where Product.QuantityInStock>120
                              select Product.ProductID;
            foreach (var id in products120)
            {
                Console.WriteLine(id);
            }

            var query = from product in products
                        join category in categories on product.CategoryID equals category.CategoryID
                        where category.Description == "Hardware"
                        select new
                        {
                            ProductName = product.Description,
                            CategoryName = category.Description
                        };

            // Display the result
            var query1 = from supplier in suppliers
                         join supplierProduct in supplierproducts on supplier.SupplierID equals supplierProduct.SupplierID
                         join product in products on supplierProduct.ProductID equals product.ProductID
                         orderby supplier.SupplierName // Order by supplier name
                         select new
                         {
                             SupplierName = supplier.SupplierName,
                             ProductName = product.Description,
                             DateFirstSupplied = supplierProduct.DateFirstSupplied
                         };

            // Display the result
            Console.WriteLine("Suppliers and their Parts:");
            foreach (var item in query1)
            {
                Console.WriteLine($"Supplier: {item.SupplierName}, Product: {item.ProductName}, Date First Supplied: {item.DateFirstSupplied.ToString("dd/MM/yyyy")}");
            }
            Console.ReadLine();
        }
    }
}
