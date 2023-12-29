using Refah.Application.Dtos.Product_Dtos;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Abstracts.Services.Product_Services
{
    [ScopedService]
    public interface IGetProductService
    {
        Task<ProductDto> GetByIdAsync(Guid id);

        Task<List<ProductDto>> GetListAsync();
    }
}
