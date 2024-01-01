using Refah.Application.Abstracts.Services.Order_Services;
using Refah.Application.Contract.Operation;
using Refah.Domain.Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Services.OrderServices
{
    [ScopedService]
    public class DeleteOrderService : IDeleteOrderService
    {
        #region [-Fields-]
        private readonly IOrderRepository orderRepository;
        #endregion

        #region [-ctor-]
        public DeleteOrderService(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }
        #endregion

        #region [-RemoveAsync(Guid id)-]
        public async Task<OperationResult> RemoveAsync(Guid id)
        {
            var operation = new OperationResult();
            var order = await orderRepository.GetByIdAsync(id);

            order.Delete();

            await orderRepository.SaveChangesAsync();
            return operation.Succedded(ApplicationMessages.Succeded);
        } 
        #endregion
    }
}
