using System;
using IntroducaoEFCore.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using IntroducaoEFCore.Domain;
using IntroducaoEFCore.ValueObjects;

namespace IntroducaoEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using ApplicationContext db = new ApplicationContext();

            db.Database.GetPendingMigrations()
            .ToList()
            .ForEach(m => Console.WriteLine(m));
            //db.Database.Migrate();

            InsertData();
            Console.WriteLine("Hello World!");
        }

        private static void InsertData()
        {
            Product product = new Product()
            {
                Description = "Test",
                BarCode = "1234567",
                Value = 10m,
                ProductType = ProductType.MerchandiseForResale,
                Actived = true
            };

            using ApplicationContext applicationContext = new ApplicationContext();
            applicationContext.Products.Add(product);
            applicationContext.SaveChanges();
            Console.WriteLine($"Produto {product.GetHashCode()} inserido na base.");
        }
    }
}
