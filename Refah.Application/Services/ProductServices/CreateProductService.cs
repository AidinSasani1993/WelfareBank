using Refah.Application.Abstracts.Services.Product_Services;
using Refah.Application.Contract.Operation;
using Refah.Application.Dtos.Product_Dtos;
using Refah.Domain.Aggregates;
using Refah.Domain.Repositories.Product_Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Services.ProductServices
{
    [ScopedService]
    public class CreateProductService : ICreateProductService
    {
        #region [-Field-]
        private readonly ICreateProductRepository createProductRepository; 
        #endregion

        #region [-ctor-]
        public CreateProductService(ICreateProductRepository createProductRepository)
        {
            this.createProductRepository = createProductRepository;
        }
        #endregion

        #region [-CreateAsync(CreateOrUpdateProductDto input)-]
        public async Task<OperationResult> CreateAsync(CreateOrUpdateProductDto input)
        {
            var operation = new OperationResult();

            var product = new Product(input.CategoryRef,
                                             input.Code,
                                             input.Title,
                                             input.Amount,
                                             input.UnitePrice,
                                             input.Image);

            if (product is null)
            {
                return operation.Failed(ApplicationMessages.Failed);
            }

            await createProductRepository.InsertAsync(product);

            return operation.Succedded(ApplicationMessages.Succeded);
        } 
        #endregion
    }
}
