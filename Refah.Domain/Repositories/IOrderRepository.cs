using Refah.Domain.Entities;
using Refah.Domain.Framework.Abstracts;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Domain.Repositories
{
    [ScopedService]
    public interface IOrderRepository : IRepository<Order, Guid>
    {
        Task<int> GetCountOrdersAsync();
    }
}
