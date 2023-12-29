using Refah.Application.Contract.Operation;
using Refah.Application.Dtos.Product_Dtos;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Abstracts.Services.Product_Services
{
    [ScopedService]
    public interface IUpdateProductService
    {
        Task<OperationResult> UpdateAsync(Guid id, CreateOrUpdateProductDto input);
    }
}
