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
        }
    }
}