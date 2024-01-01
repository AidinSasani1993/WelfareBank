using Microsoft.EntityFrameworkCore;
using Refah.Domain.Aggregates;
using Refah.Domain.Repositories;
using Refah.EntityFrameworkCore.Frameworks.Bases;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.EntityFrameworkCore.Services
{
    [ScopedService]
    public class UserRepository : Base_Repository<WelfareBankDbContext, CustomUser, Guid>,IUserRepository
    {
        #region [-ctor-]
        public UserRepository(WelfareBankDbContext dbContext) : base(dbContext)
        {
        } 
        #endregion

        #region [-GetByUserName(string userName)-]
        public async Task<CustomUser> GetByUserName(string userName)
        {
            var user = await DbSet.FirstOrDefaultAsync(a => a.UserName == userName);
            return user;
        } 
        #endregion
    }
}
