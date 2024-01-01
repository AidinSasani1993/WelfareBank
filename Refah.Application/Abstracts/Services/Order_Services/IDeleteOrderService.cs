using Refah.Application.Contract.Operation;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Abstracts.Services.Order_Services
{
    [ScopedService]
    public interface IDeleteOrderService
    {
        Task<OperationResult> RemoveAsync(Guid id);
    }
}
