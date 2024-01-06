using Microsoft.EntityFrameworkCore;
using Refah.Domain.Entities;
using Refah.Domain.Repositories;
using Refah.EntityFrameworkCore.Frameworks.Bases;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.EntityFrameworkCore.Services
{
    [ScopedService]
    public class OrderRepository : Base_Repository<WelfareBankDbContext, Order, Guid>,
                                                                            IOrderRepository
    {
        #region [-ctor-]
        public OrderRepository(WelfareBankDbContext dbContext) : base(dbContext)
        {
        } 
        #endregion

        #region [-GetCountOrdersAsync()-]
        public async Task<int> GetCountOrdersAsync()
        {
            var count = await DbSet.CountAsync();
            return count;
        } 
        #endregion
    }
}
