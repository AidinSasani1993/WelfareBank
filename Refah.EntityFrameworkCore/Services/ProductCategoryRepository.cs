using Refah.Domain.Aggregates;
using Refah.Domain.Repositories;
using Refah.EntityFrameworkCore.Frameworks.Bases;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.EntityFrameworkCore.Services
{
    [ScopedService]
    public class ProductCategoryRepository : Base_Repository<WelfareBankDbContext, ProductCategory, Guid>,
                                                                            IProductCategoryRepository
    {
        public ProductCategoryRepository(WelfareBankDbContext dbContext) : base(dbContext)
        {
        }
    }
}
