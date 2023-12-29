using Refah.Domain.Aggregates;
using Refah.Domain.Repositories.Product_Category;
using Refah.EntityFrameworkCore.Frameworks.Bases;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.EntityFrameworkCore.Services.ProductCategory_Services
{
    [ScopedService]
    public class GetProductCategoryRepository : GetRepository<WelfareBankDbContext, ProductCategory, Guid>
                                                , IGetProductCategoryRepository
    {
        #region [-ctor-]
        public GetProductCategoryRepository(WelfareBankDbContext dbContext) : base(dbContext)
        {
        } 
        #endregion
    }
}
