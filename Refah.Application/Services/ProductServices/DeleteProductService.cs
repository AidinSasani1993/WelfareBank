using Refah.Application.Abstracts.Services.Product_Services;
using Refah.Application.Contract.Operation;
using Refah.Domain.Repositories.Product_Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Services.ProductServices
{
    [ScopedService]
    public class DeleteProductService : IDeleteProductService
    {
        #region [-Fields-]
        private readonly IGetProductRepository getProductRepository;
        private readonly IUpdateProductRepository updateProductRepository; 
        #endregion

        #region [-ctor-]
        public DeleteProductService(IGetProductRepository getProductRepository,
                                    IUpdateProductRepository updateProductRepository)
        {
            this.getProductRepository = getProductRepository;
            this.updateProductRepository = updateProductRepository;
        }
        #endregion

        #region [-RemoveAsync(Guid id)-]
        public async Task<OperationResult> RemoveAsync(Guid id)
        {
            var operation = new OperationResult();

            var product = await getProductRepository.GetByIdAsync(id);

            if (product.Id == null)
            {
                operation.Failed(ApplicationMessages.Failed);
            }

            await updateProductRepository.UpdateAsync(product);

            return operation.Succedded(ApplicationMessages.Succeded);
        } 
        #endregion
    }
}
