using Refah.Application.Dtos.Order_Dtos;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Abstracts.Services.Order_Services
{
    [ScopedService]
    public interface IGetOrderService
    {
        Task<int> GetCountOrdersAsync();
        Task<OrderDto> GetByIdAsync(Guid id);
        Task<List<OrderDto>> GetListAsync();
    }
}
