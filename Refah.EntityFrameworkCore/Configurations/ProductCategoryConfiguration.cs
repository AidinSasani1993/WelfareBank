using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Refah.Domain.Entities;

namespace Refah.EntityFrameworkCore.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductType", "Production");
            builder.HasKey(p => p.Id);
            builder.Property(x => x.Title).HasMaxLength(255).IsRequired();
            builder.HasAlternateKey(x => x.CategoryCode);
            
                builder.HasMany(x => x.Products)
                .WithOne(x => x.ProductCategory)
                .HasForeignKey(x => x.CategoryRef)
                .OnDelete(DeleteBehavior.SetNull);

        }
    }
}
