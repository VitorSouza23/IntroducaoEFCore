using IntroducaoEFCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace IntroducaoEFCore.Data
{
    public class ApplicationContext : DbContext
    {

        public DbSet<Order> Orders {  get; set ; }
        public DbSet<Product> Products {  get; set ; }
        public DbSet<Customer> Customers {  get; set ;} 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=(localdb)\\mssqllocaldb;initial Catalog=IntroducaoEFCore;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
        }
    }
}