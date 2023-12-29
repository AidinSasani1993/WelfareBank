namespace Refah.Application.Contract.Abstracts
{
    public interface IDto<T_Key>
    {
        public T_Key Id { get; set; }
    }
}
