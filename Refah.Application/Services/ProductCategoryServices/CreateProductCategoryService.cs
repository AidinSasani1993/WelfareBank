using Refah.Application.Abstracts.Services.ProductCategory_Services;
using Refah.Application.Contract.Operation;
using Refah.Application.Dtos.ProductCategory_Dtos;
using Refah.Domain.Entities;
using Refah.Domain.Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Services.ProductCategoryServices
{
    [ScopedService]
    public class CreateProductCategoryService : ICreateProductCategoryService
    {
        #region [-Field-]
        private readonly IProductCategoryRepository productCategoryRepository;
        #endregion

        #region [-ctor-]
        public CreateProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }
        #endregion

        #region [-CreateAsync(CreateOrUpdateProductCategoryDto input)-]
        public async Task<OperationResult> CreateAsync(CreateOrUpdateProductCategoryDto input)
        {
            var operation = new OperationResult();
            var category = new ProductCategory(input.Title);
            await productCategoryRepository.InsertAsync(category);
            return operation.Succedded(ApplicationMessages.Succeded);
        } 
        #endregion
    }
}
