using Refah.Domain.Framework.Bases;

namespace Refah.Domain.Aggregates
{
    public class Order : BaseEntity
    {
        #region [-props-]
        public double TotalAmount { get; private set; }
        public bool IsCanceled { get; private set; } = false;
        public CustomUser CustomUser { get; private set; }
        public Guid UserRef { get; private set; } 
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
        public void Modify(double totalAmount, bool isCanceled, Guid userRef)
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
