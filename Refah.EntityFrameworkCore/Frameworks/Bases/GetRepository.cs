using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Refah.Domain.Contract.Abstracts;

namespace Refah.EntityFrameworkCore.Frameworks.Bases
{
    public class GetRepository<K_DbContext, T_Entity, T_Key> :
                                Base_Repository<K_DbContext, T_Entity, T_Key>,
                                    IGetRepository<T_Entity, T_Key>
                                        where K_DbContext : IdentityDbContext<IdentityUser>
                                            where T_Entity : class
    {
        #region [-ctor-]
        public GetRepository(K_DbContext dbContext) : base(dbContext)
        {
        }
        #endregion

        #region [-GetAllASync()-]
        public async Task<List<T_Entity>> GetAllASync()
        {
            var query = Db_Set.AsNoTracking().ToListAsync();
            return await query;
        }
        #endregion

        #region [-GetByIdAsync(T_Key id)-]
        public async Task<T_Entity> GetByIdAsync(T_Key id)
        {
            var query = await Db_Set.FindAsync(id);
            return query;
        } 
        #endregion
    }
}
