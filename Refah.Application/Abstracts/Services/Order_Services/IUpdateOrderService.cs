using Refah.Application.Contract.Operation;
using Refah.Application.Dtos.Order_Dtos;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Abstracts.Services.Order_Services
{
    [ScopedService]
    public interface IUpdateOrderService
    {
        Task<OperationResult> UpdateAsync(Guid id, CreateOrUpdateOrder input);
    }
}
