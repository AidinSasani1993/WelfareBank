namespace Refah.Domain.Framework.Abstracts
{
    public interface IEntity<Key> where Key : struct
    {
        public Key Id { get; set; }
    }
}
