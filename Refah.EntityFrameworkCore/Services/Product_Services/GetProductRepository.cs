using Refah.Domain.Aggregates;
using Refah.Domain.Repositories.Product_Repositories;
using Refah.EntityFrameworkCore.Frameworks.Bases;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.EntityFrameworkCore.Services.Product_Services
{
    [ScopedService]
    public class GetProductRepository : GetRepository<WelfareBankDbContext, Product, Guid>,
                                        IGetProductRepository
    {
        #region [-ctor-]
        public GetProductRepository(WelfareBankDbContext dbContext) : base(dbContext)
        {
        }
        #endregion

        #region [-GetByCodeAsync(string code)-]
        public async Task<Product> GetByCodeAsync(string code)
        {
            var product = await DbContext.Products.FindAsync(code);
            
            if (product is null)
            {
                return null;
            }

            return product;
        } 
        #endregion
    }
}
