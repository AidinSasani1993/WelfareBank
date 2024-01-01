using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Refah.Domain.Aggregates;

namespace Refah.EntityFrameworkCore.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<CustomUser>
    {
        public void Configure(EntityTypeBuilder<CustomUser> builder)
        {
            builder.ToTable("T", "Identity");
            builder.HasKey(p => p.Id);
            builder.Property(x => x.UserName).HasMaxLength(255).IsRequired();
            builder.Property(x => x.PasswordHash).HasMaxLength(20).IsRequired();
            builder.Property(x => x.UserName).HasColumnName("///////");
            builder.Property(x => x.PasswordHash).HasColumnName("-_-_-_-");

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.CustomUser)
                .HasForeignKey(x => x.UserRef);

        }
    }
}
