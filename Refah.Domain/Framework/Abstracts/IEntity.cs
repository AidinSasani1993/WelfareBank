namespace Refah.Domain.Framework.Abstracts
{
    public interface IEntity<Key>
    {
        public Key Id { get; set; }
    }
}
