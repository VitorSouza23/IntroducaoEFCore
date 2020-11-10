using IntroducaoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroducaoEFCore.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.BarCode).HasColumnType("VARCHAR(14)").IsRequired();
            builder.Property(c => c.Description).HasColumnType("VARCHAR(60)");
            builder.Property(c => c.Value).IsRequired();
            builder.Property(c => c.ProductType).HasConversion<string>();
        }
    }
}