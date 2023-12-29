namespace Refah.Domain.Contract.Abstracts
{
    public interface IUpdateRepository<T_Entity, T_Key> : IRepository
    {
        Task UpdateAsync(T_Entity entity);
    }
}
