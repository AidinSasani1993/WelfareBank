using Refah.Application.Abstracts.Services.Order_Services;
using Refah.Application.Contract.Operation;
using Refah.Application.Dtos.Order_Dtos;
using Refah.Domain.Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Services.OrderServices
{
    [ScopedService]
    public class UpdateOrderService : IUpdateOrderService
    {
        #region [-Fields-]
        private readonly IOrderRepository orderRepository;
        #endregion

        #region [-ctor-]
        public UpdateOrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        #endregion

        #region [-UpdateAsync(Guid id, CreateOrUpdateOrder input)-]
        public async Task<OperationResult> UpdateAsync(Guid id, CreateOrUpdateOrder input)
        {
            var operation = new OperationResult();
            var order = await orderRepository.GetByIdAsync(id);

            if (await orderRepository.Exists(a => a.Id != id))
            {
                return operation.NotFound(ApplicationMessages.RecordNotFound);
            }

            order.Modify(input.TotalAmount, input.IsCanceled, input.UserRef);
            await orderRepository.UpdateAsync(order);
            return operation.Succedded(ApplicationMessages.Succeded);
        } 
        #endregion
    }
}
