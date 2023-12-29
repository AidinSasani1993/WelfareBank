namespace Refah.Domain.Contract.Abstracts
{
    public interface IDeleteRepository<T_Entity, T_Key> : IRepository
    {
        Task DeleteAsync(T_Key id);
        Task DeleteAsync(T_Entity entity);
    }
}
