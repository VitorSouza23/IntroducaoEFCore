using IntroducaoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroducaoEFCore.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(c => c.Phone).HasColumnType("CHAR(11)");
            builder.Property(c => c.CEP).HasColumnType("CHAR(8)").IsRequired();
            builder.Property(c => c.UF).HasColumnType("CHAR(2)").IsRequired();
            builder.Property(c => c.City).HasMaxLength(60).IsRequired();

            builder.HasIndex(i => i.Phone).HasName("idx_customern_phone");
        }
    }
}