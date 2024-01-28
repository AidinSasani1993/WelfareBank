using System.Linq.Expressions;

namespace Refah.Domain.Contract
{
    public interface IRepository<TEntity, T_Key> where TEntity : class where T_Key : struct
    {
        Task<TEntity> GetByIdAsync(T_Key id);
        Task<List<TEntity>> GetAllAsync();
        Task InsertAsync(TEntity input);
        Task UpdateAsync(TEntity input);
        Task DeleteAsync(T_Key id);
        Task<bool> Exists(Expression<Func<TEntity, bool>> expression);
        Task SaveChangesAsync();
    }
}
