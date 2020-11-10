using System;
using IntroducaoEFCore.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

            Console.WriteLine("Hello World!");
        }
    }
}
