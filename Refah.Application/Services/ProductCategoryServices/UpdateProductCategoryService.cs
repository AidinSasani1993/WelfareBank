using AutoMapper;
using Refah.Application.Abstracts.Services.ProductCategory_Services;
using Refah.Application.Contract.Operation;
using Refah.Application.Dtos.ProductCategory_Dtos;
using Refah.Domain.Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Services.ProductCategoryServices
{
    [ScopedService]
    public class UpdateProductCategoryService : IUpdateProductCategoryService
    {
        #region [-Field-]
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IMapper mapper;
        #endregion

        #region [-ctor-]
        public UpdateProductCategoryService(IProductCategoryRepository productCategoryRepository,
                                            IMapper mapper)
        {
            this.productCategoryRepository = productCategoryRepository;
            this.mapper = mapper;
        }
        #endregion

        #region [-UpdateAsync(Guid id, CreateOrUpdateProductCategoryDto input)-]
        public async Task<OperationResult> UpdateAsync(Guid id, CreateOrUpdateProductCategoryDto input)
        {
            var operation = new OperationResult();
            var category = await productCategoryRepository.GetByIdAsync(id);

            if (await productCategoryRepository.Exists(a => a.Id != id))
            {
                return operation.Failed("NotFound");
            }

            category.Modify(input.Title);
            await productCategoryRepository.UpdateAsync(category);
            return operation.Succedded(ApplicationMessages.Succeded);
        } 
        #endregion
    }
}
