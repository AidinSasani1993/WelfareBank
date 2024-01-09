using Refah.Domain.Framework.Abstracts;

namespace Refah.Domain.Framework.Bases
{
    public class BaseEntity : IEntity<Guid>
    {
        #region [-props-]
        public Guid Id { get; set; }
        public bool IsDeleted { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public DateTime? ModifyDate { get; protected set; }
        public DateTime? DeletedDate { get; protected set; }
        public DateTime? ActiveDate { get; protected set; }
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
