using Refah.Application.Abstracts.Services.Product_Services;
using Refah.Application.Contract.Operation;
using Refah.Application.Dtos.Product_Dtos;
using Refah.Domain.Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Services.ProductServices
{
    [ScopedService]
    public class UpdateProductService : IUpdateProductService
    {
        #region [-Field-]
        private readonly IProductRepository productRepository;
        #endregion

        #region [-ctor-]
        public UpdateProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        #endregion

        #region [-UpdateAsync(Guid id, CreateOrUpdateProductDto input)-]
        public async Task<OperationResult> UpdateAsync(Guid id, CreateOrUpdateProductDto input)
        {
            var operation = new OperationResult();
            var product = await productRepository.GetByIdAsync(id);

            if (await productRepository.Exists(a => a.Id != id))
            {
                return operation.NotFound(ApplicationMessages.RecordNotFound);
            }

            product.Modify(input.CategoryRef,
                           input.Code,
                           input.Title,
                           input.Amount,
                           input.UnitePrice,
                           input.Image);

            await productRepository.UpdateAsync(product);

            return operation.Succedded(ApplicationMessages.Succeded);
        } 
        #endregion
    }
}
