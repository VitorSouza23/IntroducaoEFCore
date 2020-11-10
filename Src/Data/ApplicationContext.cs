using IntroducaoEFCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace IntroducaoEFCore.Data
{
    public class ApplicationContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=(localdb)\\mssqllocaldb;initial Catalog=IntroducaoEFCore;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(p =>
            {
                p.ToTable("Customers");
                p.HasKey(c => c.Id);
                p.Property(c => c.Name).HasColumnType("VARCHAR(80)").IsRequired();
                p.Property(c => c.Phone).HasColumnType("CHAR(11)");
                p.Property(c => c.CEP).HasColumnType("CHAR(8)").IsRequired();
                p.Property(c => c.UF).HasColumnType("CHAR(2)").IsRequired();
                p.Property(c => c.City).HasMaxLength(60).IsRequired();

                p.HasIndex(i => i.Phone).HasName("idx_customern_phone");
            });

            modelBuilder.Entity<Product>(p =>
            {
                p.ToTable("Products");
                p.HasKey(c => c.Id);
                p.Property(c => c.BarCode).HasColumnType("VARCHAR(14)").IsRequired();
                p.Property(c => c.Description).HasColumnType("VARCHAR(60)");
                p.Property(c => c.Value).IsRequired();
                p.Property(c => c.ProductType).HasConversion<string>();
            });

            modelBuilder.Entity<Order>(p =>
            {
                p.ToTable("Order");
                p.HasKey(c => c.Id);
                p.Property(c => c.StartIn).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
                p.Property(c => c.OrderState).HasConversion<string>();
                p.Property(c => c.FreightType).HasConversion<int>();
                p.Property(c => c.Observation).HasColumnType("VARCHAR(512)");

                p.HasMany(c => c.OrderItems)
                    .WithOne(c => c.Order)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<OrderItem>(p =>
            {
                p.ToTable("OrderItems");
                p.HasKey(c => c.Id);
                p.Property(c => c.Amount).HasDefaultValue(1).IsRequired();
                p.Property(c => c.Value).IsRequired();
                p.Property(c => c.Discount).IsRequired();
            });
        }
    }
}