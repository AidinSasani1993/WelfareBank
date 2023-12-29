using Refah.Application.Abstracts.Services.ProductCategory_Services;
using Refah.Application.Contract.Operation;
using Refah.Domain.Repositories.Product_Category;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Services.ProductCategoryServices
{
    [TransientService]
    public class DeleteProductCategoryService : IDeleteProductCategoryService
    {
        #region [-Field-]
        private readonly IGetProductCategoryRepository getProductCategoryRepository;
        private readonly IUpdateProductCategoryRepository updateProductCategoryRepository;
        #endregion

        #region [-ctor-]
        public DeleteProductCategoryService(IGetProductCategoryRepository getProductCategoryRepository,
                                            IUpdateProductCategoryRepository updateProductCategoryRepository)
        {
            this.getProductCategoryRepository = getProductCategoryRepository;
            this.updateProductCategoryRepository = updateProductCategoryRepository;
        }
        #endregion

        #region [-RemoveAsync(Guid id)-]
        public async Task<OperationResult> RemoveAsync(Guid id)
        {
            var operation = new OperationResult();
            var category = await getProductCategoryRepository.GetByIdAsync(id);
            category.Delete();
            //await repository.SaveChangesAsync();
            await updateProductCategoryRepository.UpdateAsync(category);
            return operation.Succedded(ApplicationMessages.Succeded);
        } 
        #endregion

    }
}
