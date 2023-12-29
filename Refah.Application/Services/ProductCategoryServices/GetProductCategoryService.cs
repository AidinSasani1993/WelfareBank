using AutoMapper;
using Refah.Application.Abstracts.Services.ProductCategory_Services;
using Refah.Application.Dtos.ProductCategory_Dtos;
using Refah.Domain.Repositories.Product_Category;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Services.ProductCategoryServices
{
    [ScopedService]
    public class GetProductCategoryService : IGetProductCategoryService
    {
        #region [-Fields-]
        private readonly IGetProductCategoryRepository getProductCategoryRepository;
        private readonly IMapper mapper; 
        #endregion

        #region [-ctor-]
        public GetProductCategoryService(IGetProductCategoryRepository getProductCategoryRepository,
                                         IMapper mapper)
        {
            this.getProductCategoryRepository = getProductCategoryRepository;
            this.mapper = mapper;
        }
        #endregion

        #region [-Methods-]

        #region [-GetByIdAsync(Guid id)-]
        public async Task<ProductCategoryDto> GetByIdAsync(Guid id)
        {
            var query = await getProductCategoryRepository.GetByIdAsync(id);
            return mapper.Map<ProductCategoryDto>(query);
        }
        #endregion

        #region [-GetListAsync()-]
        public async Task<List<ProductCategoryDto>> GetListAsync()
        {
            var query = await getProductCategoryRepository.GetAllASync();
            return mapper.Map<List<ProductCategoryDto>>(query);
        }
        #endregion

        #endregion
    }
}
