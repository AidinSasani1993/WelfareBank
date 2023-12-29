using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Refah.Domain.Contract.Abstracts;

namespace Refah.EntityFrameworkCore.Frameworks.Bases
{
    public class DeleteRepository<K_DbContext, T_Entity, T_Key> :
                                Base_Repository<K_DbContext, T_Entity, T_Key>,
                                IDeleteRepository<T_Entity, T_Key>
                                        where K_DbContext : IdentityDbContext<IdentityUser>
                                            where T_Entity : class
    {
        #region [-ctor-]
        public DeleteRepository(K_DbContext dbContext) : base(dbContext)
        {
        }
        #endregion

        #region [-DeleteAsync(T_Key id)-]
        public async Task DeleteAsync(T_Key id)
        {
            var entityToDelete = Db_Set.Find(id);
            Db_Set.Remove(entityToDelete);
            await SaveChangesAsync();
        }
        #endregion

        #region [-DeleteAsync(T_Entity entity)-]
        public async Task DeleteAsync(T_Entity entity)
        {
            if (DbContext.Entry(entity).State == EntityState.Detached)
            {
                Db_Set.Attach(entity);
            }
            Db_Set.Remove(entity);
            await SaveChangesAsync();
        } 
        #endregion
    }
}
