using Refah.Application.Contract.Operation;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Abstracts.Services.Product_Services
{
    [ScopedService]
    public interface IDeleteProductService
    {
        Task<OperationResult> RemoveAsync(Guid id);
    }
}
