using Refah.Domain.Aggregates;
using Refah.Domain.Contract.Abstracts;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Domain.Repositories.Product_Category
{
    [ScopedService]
    public interface IUpdateProductCategoryRepository : IUpdateRepository<ProductCategory, Guid>
    {
    }
}
