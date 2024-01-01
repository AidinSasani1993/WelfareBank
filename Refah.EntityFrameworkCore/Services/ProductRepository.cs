using Microsoft.EntityFrameworkCore;
using Refah.Domain.Aggregates;
using Refah.Domain.Repositories;
using Refah.EntityFrameworkCore.Frameworks.Bases;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.EntityFrameworkCore.Services
{
    [ScopedService]
    public class ProductRepository : Base_Repository<WelfareBankDbContext, Product, Guid>, IProductRepository
    {
        public ProductRepository(WelfareBankDbContext dbContext) : base(dbContext)
        {
        }

        #region [-GetByCodeAsync(string code)-]
        public async Task<Product> GetByCodeAsync(string code)
        {
            return await DbSet.FirstOrDefaultAsync(a => a.Code == code);
        } 
        #endregion
    }
}
