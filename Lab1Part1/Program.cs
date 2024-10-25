using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace Lab1Part1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var db = new ProductModel();
            // 6. Create code for the following queries

            // a) List all the Categories
            var sixA = db.Categories.ToList();

            // b) list all the products
            var sixB = db.Products.ToList();

            // c) list products with a quantity <= 100
            var sixcC = db.Products.Where(p => p.QuantityInStock <= 100).ToList();
            // 7. List Products with a Quantity > 120
            var sixD = db.Products.Where(p => p.QuantityInStock > 120).ToList();
            // a) List all the Products together with their total value
            var sevenA = db.Products
                .Select(p => new
                {
                    product = p,
                    totalValue = 0
                })
                .ToList();

            // b) List all the Products in the Hardware Category (use a join)
            var sevenBQuery = from p in db.Products
                              join c in db.Categories
                              on p.CategoryId equals c.Id
                              where c.Description == "Hardware"
                              select new
                              {
                                  p.Id,
                                  p.Description,
                                  p.QuantityInStock,
                                  p.UnitPrice,
                                  CategoryDescription = c.Description
                              };


            var sevenB = sevenBQuery.ToList();
            // Console.WriteLine(sevenB.ToDebugString());

            // List all the suppliers and their Parts ordered by supplier name (use a join)
            var sevenCQuery = from p in db.Products
                              join ps in db.SuppliersProducts on p.Id equals ps.ProductId
                              join s in db.Suppliers on ps.SupplierId equals s.Id
                              orderby s.SupplierName
                              select new
                              {
                                  supplier = s,
                                  product = p
                              };

            var sevenC = sevenCQuery.ToList();
            Console.WriteLine(sevenC.ToDebugString());

            Console.ReadKey();
        }
    }
    public static class DebugExtensions
    {
        public static string ToDebugString(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
        }
    }

}
