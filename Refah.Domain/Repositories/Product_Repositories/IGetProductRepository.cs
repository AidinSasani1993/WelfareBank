using Refah.Domain.Aggregates;
using Refah.Domain.Contract.Abstracts;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Domain.Repositories.Product_Repositories
{
    [ScopedService]
    public interface IGetProductRepository : IGetRepository<Product, Guid>
    {
        Task<Product> GetByCodeAsync(string code);
    }
}
