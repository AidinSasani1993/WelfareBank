using AutoMapper;
using Refah.Application.Abstracts.Services.Product_Services;
using Refah.Application.Dtos.Product_Dtos;
using Refah.Domain.Repositories.Product_Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Services.ProductServices
{
    [ScopedService]
    public class GetProductService : IGetProductService
    {
        #region [-Field-]
        private readonly IGetProductRepository getProductRepository;
        private readonly IMapper mapper; 
        #endregion

        #region [-ctor-]
        public GetProductService(IGetProductRepository getProductRepository, 
                                 IMapper mapper)
        {
            this.getProductRepository = getProductRepository;
            this.mapper = mapper;
        }
        #endregion

        #region [-Methods-]

        #region [-GetByIdAsync(Guid id)-]
        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var query = await getProductRepository.GetByIdAsync(id);
            return mapper.Map<ProductDto>(query);
        }
        #endregion

        #region [-GetListAsync()-]
        public async Task<List<ProductDto>> GetListAsync()
        {
            var query = await getProductRepository.GetAllASync();
            return mapper.Map<List<ProductDto>>(query);
        }
        #endregion

        #endregion
    }
}
