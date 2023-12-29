using Refah.Application.Dtos.ProductCategory_Dtos;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Abstracts.Services.ProductCategory_Services
{
    [ScopedService]
    public interface IGetProductCategoryService
    {
        Task<ProductCategoryDto> GetByIdAsync(Guid id);

        Task<List<ProductCategoryDto>> GetListAsync();
    }
}
