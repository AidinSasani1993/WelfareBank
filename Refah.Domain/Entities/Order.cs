using Refah.Domain.Framework.Bases;

namespace Refah.Domain.Entities
{
    public class Order : BaseEntity
    {
        #region [-props-]
        public double TotalAmount { get; protected set; }
        public bool? IsCanceled { get; protected set; } = false;
        public CustomUser CustomUser { get; protected set; }
        public Guid UserRef { get; protected set; } 
        #endregion

        #region [-ctor-]
        public Order(double totalAmount,
                     Guid userRef)
        {
            TotalAmount = totalAmount;
            IsCanceled = false;
            UserRef = userRef;
        }
        #endregion

        #region [-Modify(double totalAmount, bool isCanceled, Guid userRef)-]
        public void Modify(double totalAmount, bool? isCanceled, Guid userRef)
        {
            TotalAmount = totalAmount;
            IsCanceled = isCanceled;
            UserRef = userRef;
        }
        #endregion

        #region [-Cancel()-]
        public void Cancel()
        {
            IsCanceled = true;
        } 
        #endregion

    }
}
