using AutoMapper;
using Refah.Application.Abstracts.Services.ProductCategory_Services;
using Refah.Application.Contract.Operation;
using Refah.Application.Dtos.ProductCategory_Dtos;
using Refah.Domain.Repositories.Product_Category;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Services.ProductCategoryServices
{
    [ScopedService]
    public class UpdateProductCategoryService : IUpdateProductCategoryService
    {
        #region [-Field-]
        private readonly IUpdateProductCategoryRepository updateProductCategoryRepository;
        private readonly IGetProductCategoryRepository getProductCategoryRepository;
        private readonly IMapper mapper;
        #endregion

        #region [-ctor-]
        public UpdateProductCategoryService(IUpdateProductCategoryRepository updateProductCategoryRepository,
                                            IGetProductCategoryRepository getProductCategoryRepository,
                                            IMapper mapper)
        {
            this.updateProductCategoryRepository = updateProductCategoryRepository;
            this.getProductCategoryRepository = getProductCategoryRepository;
            this.mapper = mapper;
        }
        #endregion

        #region [-UpdateAsync(Guid id, CreateOrUpdateProductCategoryDto input)-]
        public async Task<OperationResult> UpdateAsync(Guid id, CreateOrUpdateProductCategoryDto input)
        {
            var operation = new OperationResult();
            var category = await getProductCategoryRepository.GetByIdAsync(id);

            category.Modify(input.Title);
            await updateProductCategoryRepository.UpdateAsync(category);
            return operation.Succedded(ApplicationMessages.Succeded);
        } 
        #endregion
    }
}
