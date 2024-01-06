using Refah.Domain.Entities;
using Refah.Domain.Contract.Abstracts;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Domain.Repositories
{
    [ScopedService]
    public interface IOrderRepository : IRepository<Order, Guid>
    {
        Task<int> GetCountOrdersAsync();
    }
}
