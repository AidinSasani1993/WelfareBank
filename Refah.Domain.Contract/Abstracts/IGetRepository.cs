namespace Refah.Domain.Contract.Abstracts
{
    public interface IGetRepository<T_Entity , T_Key> 
    {
        Task<List<T_Entity>> GetAllASync();
        Task<T_Entity> GetByIdAsync(T_Key id);
    }
}
