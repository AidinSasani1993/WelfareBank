namespace Refah.Domain.Contract.Abstracts
{
    public interface IRepository
    {
        Task SaveChangesAsync();
    }
}
