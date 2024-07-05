using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineStore.Domain.Products;

namespace OnlineStore.Infrastructure.Persistence.EF.Products.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasMaxLength(40);
            builder.HasIndex(x => x.Title).IsUnique();
            builder.Property(x => x.InventoryCount).HasDefaultValue(1);
            builder.Property(x => x.Price);
            builder.Property(x => x.Discount);
        }
    }
}
