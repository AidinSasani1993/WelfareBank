using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Refah.Domain.Aggregates;

namespace Refah.EntityFrameworkCore.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("*******", "Production");
            builder.HasKey(p => p.Id);
            builder.Property(x => x.Id).HasColumnName("Pi");
            builder.Property(x => x.Title).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Title).HasColumnName("====");
            builder.Property(x => x.Title).HasMaxLength(50);
        }
    }
}
