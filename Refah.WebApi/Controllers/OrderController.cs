using Microsoft.AspNetCore.Mvc;
using Refah.Application.Abstracts.Services.Order_Services;
using Refah.Application.Contract.Operation;
using Refah.Application.Dtos.Order_Dtos;

namespace Refah.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        #region [-Fields-]
        private readonly IGetOrderService getOrderService;
        private readonly ICreateOrderService createOrderService;
        private readonly IUpdateOrderService updateOrderService;
        private readonly IDeleteOrderService deleteOrderService; 
        #endregion

        #region [-ctor-]
        public OrderController(IGetOrderService getOrderService,
                               ICreateOrderService createOrderService,
                               IUpdateOrderService updateOrderService,
                               IDeleteOrderService deleteOrderService)
        {
            this.getOrderService = getOrderService;
            this.createOrderService = createOrderService;
            this.updateOrderService = updateOrderService;
            this.deleteOrderService = deleteOrderService;
        }
        #endregion

        #region [-Actions-]

        #region [-GetListAsync()-]
        [HttpGet]
        public async Task<List<OrderDto>> GetListAsync()
        {
            return await getOrderService.GetListAsync();
        }
        #endregion

        #region [-GetByIdAsync(Guid id)-]
        [HttpGet("{id}")]
        public async Task<OrderDto> GetByIdAsync(Guid id)
        {
            return await getOrderService.GetByIdAsync(id);
        }
        #endregion

        #region [-GetCountOrdersAsync()-]
        [HttpGet("count")]
        public async Task<int> GetCountOrdersAsync()
        {
            return await getOrderService.GetCountOrdersAsync();
        }
        #endregion

        #region [-CreateAsync(CreateOrUpdateOrder input)-]
        [HttpPost]
        public async Task<OperationResult> CreateAsync(CreateOrUpdateOrder input)
        {
            return await createOrderService.CreateAsync(input);
        }
        #endregion

        #region [-UpdateAsync(Guid id, CreateOrUpdateOrder input)-]
        [HttpPut]
        public async Task<OperationResult> UpdateAsync(Guid id, CreateOrUpdateOrder input)
        {
            return await updateOrderService.UpdateAsync(id, input);
        }
        #endregion

        #region [-RemoveAsync(Guid id)-]
        [HttpDelete]
        public async Task<OperationResult> RemoveAsync(Guid id)
        {
            return await deleteOrderService.RemoveAsync(id);
        }
        #endregion

        #endregion
    }
}
