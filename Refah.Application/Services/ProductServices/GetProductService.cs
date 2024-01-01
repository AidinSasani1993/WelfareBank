using AutoMapper;
using Refah.Application.Abstracts.Services.Product_Services;
using Refah.Application.Dtos.Product_Dtos;
using Refah.Domain.Repositories;
using Refah.Domain.Repositories.Product_Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Services.ProductServices
{
    [ScopedService]
    public class GetProductService : IGetProductService
    {
        #region [-Field-]
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper; 
        #endregion

        #region [-ctor-]
        public GetProductService(IProductRepository productRepository, 
                                 IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        #endregion

        #region [-Methods-]

        #region [-GetByIdAsync(Guid id)-]
        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var query = await productRepository.GetByIdAsync(id);
            return mapper.Map<ProductDto>(query);
        }
        #endregion

        #region [-GetListAsync()-]
        public async Task<List<ProductDto>> GetListAsync()
        {
            var query = await productRepository.GetAllAsync();
            return mapper.Map<List<ProductDto>>(query);
        }
        #endregion

        #endregion
    }
}
