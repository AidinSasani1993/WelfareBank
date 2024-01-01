using Refah.Application.Abstracts.Services.ProductCategory_Services;
using Refah.Application.Contract.Operation;
using Refah.Domain.Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Services.ProductCategoryServices
{
    [ScopedService]
    public class DeleteProductCategoryService : IDeleteProductCategoryService
    {
        #region [-Field-]
        private readonly IProductCategoryRepository productCategoryRepository;
        #endregion

        #region [-ctor-]
        public DeleteProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }
        #endregion

        #region [-RemoveAsync(Guid id)-]
        public async Task<OperationResult> RemoveAsync(Guid id)
        {
            var operation = new OperationResult();
            var category = await productCategoryRepository.GetByIdAsync(id);
            
            if (await productCategoryRepository.Exists(a => a.Id != id))
            {
                return operation.NotFound(ApplicationMessages.RecordNotFound);
            }

            category.Delete();
            await productCategoryRepository.UpdateAsync(category);
            return operation.Succedded(ApplicationMessages.Succeded);
        } 
        #endregion

    }
}
