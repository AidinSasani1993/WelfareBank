using Refah.Domain.Aggregates;
using Refah.Domain.Repositories.Product_Category;
using Refah.EntityFrameworkCore.Frameworks.Bases;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.EntityFrameworkCore.Services.ProductCategory_Services
{
    [ScopedService]
    public class UpdateProductCategoryRepository : UpdateRepository<WelfareBankDbContext, ProductCategory, Guid>
                                                    , IUpdateProductCategoryRepository
    {
        #region [-ctor-]
        public UpdateProductCategoryRepository(WelfareBankDbContext dbContext) : base(dbContext)
        {
        } 
        #endregion
    }
}
