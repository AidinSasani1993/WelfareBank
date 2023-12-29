using Refah.Application.Abstracts.Services.Product_Services;
using Refah.Application.Contract.Operation;
using Refah.Application.Dtos.Product_Dtos;
using Refah.Domain.Repositories.Product_Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Services.ProductServices
{
    [ScopedService]
    public class UpdateProductService : IUpdateProductService
    {
        #region [-Field-]
        private readonly IUpdateProductRepository updateProductRepository;
        private readonly IGetProductRepository getProductRepository;
        #endregion

        #region [-ctor-]
        public UpdateProductService(IUpdateProductRepository updateProductRepository,
                                    IGetProductRepository getProductRepository)
        {
            this.updateProductRepository = updateProductRepository;
            this.getProductRepository = getProductRepository;
        }
        #endregion

        #region [-UpdateAsync(Guid id, CreateOrUpdateProductDto input)-]
        public async Task<OperationResult> UpdateAsync(Guid id, CreateOrUpdateProductDto input)
        {
            var operation = new OperationResult();
            var product = await getProductRepository.GetByIdAsync(id);

            if (Guid.Empty == input.CategoryRef) 
            {
                return operation.Failed(ApplicationMessages.Failed);
            }

            product.Modify(input.CategoryRef,
                           input.Code,
                           input.Title,
                           input.Amount,
                           input.UnitePrice,
                           input.Image);

            await updateProductRepository.UpdateAsync(product);

            return operation.Succedded(ApplicationMessages.Succeded);
        } 
        #endregion
    }
}
