using IntroducaoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroducaoEFCore.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.StartIn).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(c => c.OrderState).HasConversion<string>();
            builder.Property(c => c.FreightType).HasConversion<int>();
            builder.Property(c => c.Observation).HasColumnType("VARCHAR(512)");

            builder.HasMany(c => c.OrderItems)
                .WithOne(c => c.Order)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}