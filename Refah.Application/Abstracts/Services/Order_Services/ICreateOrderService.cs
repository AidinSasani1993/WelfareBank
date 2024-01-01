using Refah.Application.Contract.Operation;
using Refah.Application.Dtos.Order_Dtos;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Abstracts.Services.Order_Services
{
    [ScopedService]
    public interface ICreateOrderService
    {
        Task<OperationResult> CreateAsync(CreateOrUpdateOrder input);
    }
}
