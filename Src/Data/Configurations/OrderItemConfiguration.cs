using IntroducaoEFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IntroducaoEFCore.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Amount).HasDefaultValue(1).IsRequired();
            builder.Property(c => c.Value).IsRequired();
            builder.Property(c => c.Discount).IsRequired();
        }
    }
}