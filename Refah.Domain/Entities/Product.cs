using Refah.Domain.Framework.Bases;

namespace Refah.Domain.Entities
{
    public class Product : BaseEntity
    {
        #region [-props-]
        public ProductCategory ProductCategory { get; protected set; }
        public Guid CategoryRef { get; protected set; }
        public string Code { get; protected set; }
        public string Title { get; protected set; }
        public int Amount { get; protected set; }
        public decimal UnitePrice { get; protected set; }
        public string Image { get; protected set; } 
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
