using Refah.Domain.Framework.Bases;

namespace Refah.Domain.Entities
{
    public class ProductCategory : BaseEntity
    {
        public string Title { get; private set; }
        public List<Product> Products { get; private set; }


        public ProductCategory(string title)
        {
            Title = title;
        }

        public void Modify(string title)
        {
            Title = title;
        }

    }
}
