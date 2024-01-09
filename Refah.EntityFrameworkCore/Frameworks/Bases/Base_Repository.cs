using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Refah.Domain.Framework.Abstracts;
using System.Linq.Expressions;

namespace Refah.EntityFrameworkCore.Frameworks.Bases
{
    public class Base_Repository<K_DbContext, T_Entity, T_Key> : IRepository<T_Entity, T_Key>
                                                                          where T_Entity : class
                                                                          where K_DbContext : IdentityDbContext<IdentityUser>
                                                                          where T_Key : struct
    {
        public virtual K_DbContext DbContext { get; set; }
        public virtual DbSet<T_Entity> DbSet { get; set; }

        public Base_Repository(K_DbContext dbContext)
        {
            DbContext = dbContext;
            DbSet = dbContext.Set<T_Entity>();
        }

        public async Task DeleteAsync(T_Key id)
        {
            var query = await DbSet.FindAsync(id);
            DbSet.Remove(query);
            await SaveChangesAsync();
        }

        public async Task<bool> Exists(Expression<Func<T_Entity, bool>> expression)
        {
            return await DbContext.Set<T_Entity>().AnyAsync(expression);
        }

        public async Task<List<T_Entity>> GetAllAsync()
        {
            var query = DbSet.AsNoTracking().ToListAsync();
            return await query;
        }

        public async Task<T_Entity> GetByIdAsync(T_Key id)
        {
            var query = await DbSet.FindAsync(id);
            return query;
        }

        public async Task InsertAsync(T_Entity input)
        {
            using (DbContext)
            {
                await DbSet.AddAsync(input);
                await SaveChangesAsync();
            }
        }

        public async Task SaveChangesAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T_Entity input)
        {
            DbSet.Attach(input);
            DbContext.Entry(input).State = EntityState.Modified;
            await SaveChangesAsync();
        }
    }
}
