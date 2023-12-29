using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Refah.Domain.Contract.Abstracts;

namespace Refah.EntityFrameworkCore.Frameworks.Bases
{
    public class CreateRepository<K_DbContext, T_Entity, T_Key> :
                                Base_Repository<K_DbContext, T_Entity, T_Key>,
                                    ICreateRepository<T_Entity, T_Key>
                                        where K_DbContext : IdentityDbContext<IdentityUser>
                                            where T_Entity : class
    {
        #region [-ctor-]
        public CreateRepository(K_DbContext dbContext) : base(dbContext)
        {
        }
        #endregion

        #region [-InsertAsync(T_Entity entity)-]
        public async Task InsertAsync(T_Entity entity)
        {
            using (DbContext)
            {
                await Db_Set.AddAsync(entity);
                await SaveChangesAsync();
            }
        } 
        #endregion
    }
}
