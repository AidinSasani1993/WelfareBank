using Refah.Application.Contract.Operation;
using Refah.Application.Dtos.ProductCategory_Dtos;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Abstracts.Services.ProductCategory_Services
{
    [ScopedService]
    public interface IUpdateProductCategoryService
    {
        Task<OperationResult> UpdateAsync(Guid id, CreateOrUpdateProductCategoryDto input);
    }
}
