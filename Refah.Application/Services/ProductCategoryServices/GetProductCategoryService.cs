using AutoMapper;
using Refah.Application.Abstracts.Services.ProductCategory_Services;
using Refah.Application.Dtos.ProductCategory_Dtos;
using Refah.Domain.Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Services.ProductCategoryServices
{
    [ScopedService]
    public class GetProductCategoryService : IGetProductCategoryService
    {
        #region [-Fields-]
        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IMapper mapper; 
        #endregion

        #region [-ctor-]
        public GetProductCategoryService(IProductCategoryRepository productCategoryRepository,
                                         IMapper mapper)
        {
            this.productCategoryRepository = productCategoryRepository;
            this.mapper = mapper;
        }
        #endregion

        #region [-Methods-]

        #region [-GetByIdAsync(Guid id)-]
        public async Task<ProductCategoryDto> GetByIdAsync(Guid id)
        {
            var query = await productCategoryRepository.GetByIdAsync(id);
            return mapper.Map<ProductCategoryDto>(query);
        }
        #endregion

        #region [-GetListAsync()-]
        public async Task<List<ProductCategoryDto>> GetListAsync()
        {
            var query = await productCategoryRepository.GetAllAsync();
            return mapper.Map<List<ProductCategoryDto>>(query);
        }
        #endregion

        #endregion
    }
}
