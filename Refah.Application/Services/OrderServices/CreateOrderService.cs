using Refah.Application.Abstracts.Services.Order_Services;
using Refah.Application.Contract.Operation;
using Refah.Application.Dtos.Order_Dtos;
using Refah.Domain.Entities;
using Refah.Domain.Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Services.OrderServices
{
    [ScopedService]
    public class CreateOrderService : ICreateOrderService
    {
        #region [-Fields-]
        private readonly IOrderRepository orderRepository;
        #endregion

        #region [-ctor-]
        public CreateOrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        #endregion

        #region [-CreateAsync(CreateOrUpdateOrder input)-]
        public async Task<OperationResult> CreateAsync(CreateOrUpdateOrder input)
        {
            var operation = new OperationResult();
            var order = new Order(input.TotalAmount, input.UserRef);
            await orderRepository.InsertAsync(order);
            return operation.Succedded(ApplicationMessages.Succeded);
        } 
        #endregion
    }
}
