using Refah.Domain.Aggregates;
using Refah.Domain.Repositories.Product_Repositories;
using Refah.EntityFrameworkCore.Frameworks.Bases;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.EntityFrameworkCore.Services.Product_Services
{
    [ScopedService]
    public class UpdateProductRepository : CreateRepository<WelfareBankDbContext, Product, Guid>,
                                            IUpdateProductRepository
    {
        public UpdateProductRepository(WelfareBankDbContext dbContext) : base(dbContext)
        {
        }

        public Task UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
