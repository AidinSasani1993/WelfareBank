using Refah.Domain.Framework.Bases;

namespace Refah.Domain.Aggregates
{
    public class Product : BaseEntity
    {
        #region [-props-]
        public ProductCategory ProductCategory { get; private set; }
        public Guid CategoryRef { get; private set; }
        public string Code { get; private set; }
        public string Title { get; private set; }
        public int Amount { get; private set; }
        public decimal UnitePrice { get; private set; }
        public string Image { get; private set; } 
        #endregion

        #region [-ctor-]
        public Product(Guid categoryRef,
                       string code,
                       string title, 
                       int amount, 
                       decimal unitePrice, 
                       string image)
        {
            CategoryRef = categoryRef;
            Code = code;
            Title = title;
            Amount = amount;
            UnitePrice = unitePrice;
            Image = image;
        }
        #endregion

        #region [-Modify(Guid categoryRef,string title,int amount,decimal unitePrice,string image-]
        public void Modify(Guid categoryRef,
                           string code,
                           string title,
                           int amount,
                           decimal unitePrice,
                           string image)
        {
            CategoryRef = categoryRef;
            Code = code;
            Title = title;
            Amount = amount;
            UnitePrice = unitePrice;
            Image = image;
        } 
        #endregion
    }
}
