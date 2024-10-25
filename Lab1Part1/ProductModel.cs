using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Part1
{
    public class ProductModel
    {
        public List<Product> Products { get; } = new List<Product>()
        {
            new Product { Id = 1, Description = "9 Inch Nails", QuantityInStock = 200, UnitPrice = 0.1, CategoryId = 1 },
            new Product { Id = 2, Description = "9 Inch Bolts", QuantityInStock = 120, UnitPrice = 0.2, CategoryId = 1 },
            new Product { Id = 3, Description = "Chimney Hoover", QuantityInStock = 10, UnitPrice = 100.30, CategoryId = 2 },
            new Product { Id = 4, Description = "Washing Machine", QuantityInStock = 7, UnitPrice = 399.50, CategoryId = 2 },
        };
        public List<Supplier> Suppliers { get; } = new List<Supplier>()
        {
            new Supplier { Id = 1, SupplierName = "ACME", AddressLine1 = "Collooney", AddressLine2 = "Sligo" },
            new Supplier { Id = 2, SupplierName = "Swift Electric", AddressLine1 = "Finglas", AddressLine2 = "Dublin" },
        };

        public List<Category> Categories { get; } = new List<Category>()
        {
            new Category { Id = 1, Description = "Hardware" },
            new Category { Id = 2, Description = "Electrical Appliances" },
        };

        public List<SupplierProduct> SuppliersProducts { get; } = new List<SupplierProduct>()
        {
            new SupplierProduct { SupplierId = 1, ProductId = 1, DateFirstSupplied = new DateTime(2012, 12, 12) },
            new SupplierProduct { SupplierId = 1, ProductId = 2, DateFirstSupplied = new DateTime(2017, 8, 13) },
            new SupplierProduct { SupplierId = 2, ProductId = 3, DateFirstSupplied = new DateTime(2022, 9, 9) },
            new SupplierProduct { SupplierId = 2, ProductId = 4, DateFirstSupplied = new DateTime(2024, 4, 11) },
        };
    }

}
