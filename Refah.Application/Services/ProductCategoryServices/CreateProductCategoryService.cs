using Refah.Application.Abstracts.Services.ProductCategory_Services;
using Refah.Application.Contract.Operation;
using Refah.Application.Dtos.ProductCategory_Dtos;
using Refah.Domain.Aggregates;
using Refah.Domain.Repositories.Product_Category;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Services.ProductCategoryServices
{
    [ScopedService]
    public class CreateProductCategoryService : ICreateProductCategoryService
    {
        #region [-Field-]
        private readonly ICreateProductCategoryRepository createProductCategoryRepository;
        #endregion

        #region [-ctor-]
        public CreateProductCategoryService(ICreateProductCategoryRepository createProductCategoryRepository)
        {
            this.createProductCategoryRepository = createProductCategoryRepository;
        }
        #endregion

        #region [-CreateAsync(CreateOrUpdateProductCategoryDto input)-]
        public async Task<OperationResult> CreateAsync(CreateOrUpdateProductCategoryDto input)
        {
            var operation = new OperationResult();
            var category = new ProductCategory(input.Title);
            await createProductCategoryRepository.InsertAsync(category);
            return operation.Succedded(ApplicationMessages.Succeded);
        } 
        #endregion
    }
}
