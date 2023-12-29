using Refah.Domain.Framework.Abstracts;

namespace Refah.Domain.Framework.Bases
{
    public class BaseEntity : IEntity<Guid>
    {
        #region [-props-]
        public Guid Id { get; set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? ModifyDate { get; private set; }
        public DateTime? DeletedDate { get; private set; }
        public DateTime? ActiveDate { get; private set; }
        #endregion

        #region [-Methods-]

        #region [-ctor-]
        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
        }
        #endregion

        #region [-Modify-]
        public void Modify()
        {
            ModifyDate = DateTime.Now;
        }
        #endregion

        #region [-Delete()-]
        public void Delete()
        {
            IsDeleted = true;
            DeletedDate = DateTime.Now;
        }
        #endregion

        #region [-Active()-]
        public void Active()
        {
            IsDeleted = false;
            ActiveDate = DateTime.Now;
        }
        #endregion

        #endregion
    }
}
