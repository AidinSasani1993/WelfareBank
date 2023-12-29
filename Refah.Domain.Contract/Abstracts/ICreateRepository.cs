namespace Refah.Domain.Contract.Abstracts
{
    public interface ICreateRepository<T_Entity, T_Key> : IRepository
    {
        Task InsertAsync(T_Entity entity);
    }
}
