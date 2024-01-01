using AutoMapper;
using Refah.Application.Abstracts.Services.Order_Services;
using Refah.Application.Dtos.Order_Dtos;
using Refah.Domain.Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Services.OrderServices
{
    [ScopedService]
    public class GetOrderService : IGetOrderService
    {
        #region [-Fields-]
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper; 
        #endregion

        #region [-ctor-]
        public GetOrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;
        }
        #endregion

        #region [-GetByIdAsync(Guid id)-]
        public async Task<OrderDto> GetByIdAsync(Guid id)
        {
            var query = await orderRepository.GetByIdAsync(id);
            return mapper.Map<OrderDto>(query);
        }
        #endregion

        #region [-GetCountOrdersAsync()-]
        public async Task<int> GetCountOrdersAsync()
        {
            return await orderRepository.GetCountOrdersAsync();
        }
        #endregion

        #region [-GetListAsync()-]
        public async Task<List<OrderDto>> GetListAsync()
        {
            var query = await orderRepository.GetAllAsync();
            return mapper.Map<List<OrderDto>>(query);
        } 
        #endregion
    }
}
