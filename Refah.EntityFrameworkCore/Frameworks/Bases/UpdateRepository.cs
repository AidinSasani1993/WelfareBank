using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Refah.Domain.Contract.Abstracts;

namespace Refah.EntityFrameworkCore.Frameworks.Bases
{
    public class UpdateRepository<K_DbContext, T_Entity, T_Key> :
                                Base_Repository<K_DbContext, T_Entity, T_Key>,
                                    IUpdateRepository<T_Entity, T_Key>
                                        where K_DbContext : IdentityDbContext<IdentityUser>
                                            where T_Entity : class
    {
        #region [-ctor-]
        public UpdateRepository(K_DbContext dbContext) : base(dbContext)
        {
        }
        #endregion

        #region [-UpdateAsync(T_Entity entity)-]
        public async Task UpdateAsync(T_Entity entity)
        {
            Db_Set.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
            await SaveChangesAsync();
        } 
        #endregion
    }
}
