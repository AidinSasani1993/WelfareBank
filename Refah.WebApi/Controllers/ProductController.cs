using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Refah.Application.Abstracts.Services.Product_Services;
using Refah.Application.Dtos.Product_Dtos;

namespace Refah.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region [-Fields-]
        private readonly IGetProductService getProductService;
        private readonly IUpdateProductService updateProductService;
        private readonly ICreateProductService createProductService;
        private readonly IDeleteProductService deleteProductService; 
        #endregion

        #region [-ctor-]
        public ProductController(IGetProductService getProductService,
                                 IUpdateProductService updateProductService,
                                 ICreateProductService createProductService,
                                 IDeleteProductService deleteProductService)
        {
            this.getProductService = getProductService;
            this.updateProductService = updateProductService;
            this.createProductService = createProductService;
            this.deleteProductService = deleteProductService;
        }
        #endregion

        #region [-GetListAsync()-]
        [HttpGet("product")]
        [Authorize(Roles = "Customer")]
        public async Task<List<ProductDto>> GetListAsync()
        {
            return await getProductService.GetListAsync();
        }
        #endregion

        #region [-GetByIdAsync(Guid id)-]
        [HttpGet("product/{id}")]
        [Authorize(Roles = "Customer")]
        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            return await getProductService.GetByIdAsync(id);
        }
        #endregion

        #region [CreateAsync(CreateOrUpdateProductDto input)-]
        [HttpPost("product")]
        [Authorize(Roles = "Customer")]
        public async Task CreateAsync(CreateOrUpdateProductDto input)
        {
            await createProductService.CreateAsync(input);
        }
        #endregion

        #region [UpdateAsync(CreateOrUpdateProductDto input)-]
        [HttpPut("product/{id}")]
        [Authorize(Roles = "Customer")]
        public async Task UpdateAsync(Guid id, CreateOrUpdateProductDto input)
        {
            await updateProductService.UpdateAsync(id, input);
        }
        #endregion

        #region [DeleteAsync(CreateOrUpdateProductDto input)-]
        [HttpDelete("product/{id}")]
        [Authorize(Roles = "Customer")]
        public async Task DeleteAsync(Guid id)
        {
            await deleteProductService.RemoveAsync(id);
        }
        #endregion

    }
}
