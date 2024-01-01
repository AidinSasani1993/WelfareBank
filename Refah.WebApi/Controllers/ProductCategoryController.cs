using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Refah.Application.Abstracts.Services.ProductCategory_Services;
using Refah.Application.Dtos.ProductCategory_Dtos;

namespace Refah.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        #region [-Fields-]
        private readonly IGetProductCategoryService getProductCategoryService;
        private readonly ICreateProductCategoryService createProductCategoryService;
        private readonly IUpdateProductCategoryService updateProductCategoryService;
        private readonly IDeleteProductCategoryService deleteProductCategoryService; 
        #endregion

        #region [-ctor-]
        public ProductCategoryController(IGetProductCategoryService getProductCategoryService,
                                         ICreateProductCategoryService createProductCategoryService,
                                         IUpdateProductCategoryService updateProductCategoryService,
                                         IDeleteProductCategoryService deleteProductCategoryService)
        {
            this.getProductCategoryService = getProductCategoryService;
            this.createProductCategoryService = createProductCategoryService;
            this.updateProductCategoryService = updateProductCategoryService;
            this.deleteProductCategoryService = deleteProductCategoryService;
        }
        #endregion


        #region [-GetListAsync()-]
        [HttpGet("category")]
        [Authorize(Roles = "Customer")]
        public async Task<List<ProductCategoryDto>> GetListAsync()
        {
            return await getProductCategoryService.GetListAsync();
        }
        #endregion


        [HttpGet("category/{id}")]
        [Authorize(Roles = "Customer")]
        public async Task<ProductCategoryDto> GetByIdAsync(Guid id)
        {
            return await getProductCategoryService.GetByIdAsync(id);
        }

        [HttpPost("category")]
        [Authorize(Roles = "Customer")]
        public async Task CreateAsync(CreateOrUpdateProductCategoryDto input)
        {
            await createProductCategoryService.CreateAsync(input);
        }

        [HttpPut("category/{id}")]
        [Authorize(Roles = "Customer")]
        public async Task UpdateAsync(Guid id, CreateOrUpdateProductCategoryDto input)
        {
            await updateProductCategoryService.UpdateAsync(id, input);
        }

        [HttpDelete("category/{id}")]
        [Authorize(Roles = "Customer")]
        public async Task DeleteAsync(Guid id)
        {
            await deleteProductCategoryService.RemoveAsync(id);
        }


    }
}
