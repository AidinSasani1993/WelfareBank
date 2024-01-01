using Refah.Application.Abstracts.Services.Product_Services;
using Refah.Application.Contract.Operation;
using Refah.Domain.Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Services.ProductServices
{
    [ScopedService]
    public class DeleteProductService : IDeleteProductService
    {
        #region [-Fields-]
        private readonly IProductRepository productRepository;
        #endregion

        #region [-ctor-]
        public DeleteProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        #endregion

        #region [-RemoveAsync(Guid id)-]
        public async Task<OperationResult> RemoveAsync(Guid id)
        {
            var operation = new OperationResult();

            var product = await productRepository.GetByIdAsync(id);

            if (await productRepository.Exists(a => a.Id != id))
            {
                return operation.NotFound(ApplicationMessages.RecordNotFound);
            }

            await productRepository.UpdateAsync(product);

            return operation.Succedded(ApplicationMessages.Succeded);
        } 
        #endregion
    }
}
