using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Refah.Domain.Aggregates;
using Refah.EntityFrameworkCore.Configurations;

namespace Refah.EntityFrameworkCore
{
    public class WelfareBankDbContext : IdentityDbContext<IdentityUser>
    {
        #region [-ctors-]
        public WelfareBankDbContext(DbContextOptions<WelfareBankDbContext> contextOptions)
            : base(contextOptions)
        {

        }
        protected WelfareBankDbContext()
        {

        }
        #endregion

        #region [-props-]
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<CustomUser> CustomUsers { get; set; }
        #endregion

        #region [-OnModelCreating(ModelBuilder builder)-]
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var assembely = typeof(ProductCategoryConfiguration).Assembly;
            builder.ApplyConfigurationsFromAssembly(assembely);
            base.OnModelCreating(builder);
        } 
        #endregion
    }
}
