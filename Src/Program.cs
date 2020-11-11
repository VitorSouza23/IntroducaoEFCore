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

            //InsertData();
            InsertDataRange();
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

        private static void InsertDataRange()
        {
            Product product = new Product()
            {
                Description = "Test",
                BarCode = "1234567",
                Value = 10m,
                ProductType = ProductType.MerchandiseForResale,
                Actived = true
            };

            Customer customer = new Customer()
            {
                CEP = "999999",
                City = "Teste",
                Name = "Teste",
                UF = "AA",
                Phone = "1111111"
            };

            using ApplicationContext applicationContext = new ApplicationContext();
            applicationContext.AddRange(product, customer);
            applicationContext.SaveChanges();
        }
    }
}
