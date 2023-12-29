using Refah.Domain.Aggregates;
using Refah.Domain.Repositories.Product_Category;
using Refah.EntityFrameworkCore.Frameworks.Bases;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.EntityFrameworkCore.Services.ProductCategory_Services
{
    [ScopedService]
    public class CreateProductCategoryRepository : CreateRepository<WelfareBankDbContext, ProductCategory, Guid>
                                                    , ICreateProductCategoryRepository
    {
        #region [-ctor-]
        public CreateProductCategoryRepository(WelfareBankDbContext dbContext) : base(dbContext)
        {
        } 
        #endregion
    }
}
