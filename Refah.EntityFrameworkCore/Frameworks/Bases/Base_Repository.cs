using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Refah.Domain.Contract.Abstracts;

namespace Refah.EntityFrameworkCore.Frameworks.Bases
{
    public class Base_Repository<K_DbContext, T_Entity, T_Key> : IRepository 
                                                        where K_DbContext : IdentityDbContext<IdentityUser>
                                                        where T_Entity : class
    {
        #region [-ctor-]
        public Base_Repository(K_DbContext dbContext)
        {
            DbContext = dbContext;
            Db_Set = dbContext.Set<T_Entity>();
        } 
        #endregion

        #region [-props-]
        public virtual K_DbContext DbContext { get; set; }
        public virtual DbSet<T_Entity> Db_Set { get; set; }
        #endregion

        #region [-SaveChangesAsync()-]
        public async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        } 
        #endregion
    }
}
