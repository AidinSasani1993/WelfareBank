using Microsoft.AspNetCore.Identity;

namespace Refah.Domain.Aggregates
{
    public class CustomUser : IdentityUser
    {
        #region [-props-]
        public string FName { get; private set; }
        public string LName { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? ModifyDate { get; private set; }
        public bool IsActive { get; private set; } = true;
        public DateTime? NonActiveDate { get; private set; }
        public DateTime? ActiveDate { get; private set; }

        #endregion

        #region [-ctor-]
        public CustomUser(string fName,
                          string lName, 
                          string userName, 
                          string password, 
                          string email)
        {
            FName = fName;
            LName = lName;
            UserName = userName;
            PasswordHash = password;
            Email = email;
            CreatedDate = DateTime.Now;
        }
        #endregion

        #region [-Modify(string fName, string lName, string userName, string password, string email)-]
        public void Modify(string fName,
                           string lName, 
                           string userName, 
                           string password, 
                           string email)
        {
            FName = fName;
            LName = lName;
            UserName = userName;
            PasswordHash = password;
            Email = email;
            ModifyDate = DateTime.Now;
        }
        #endregion

        #region [-NonActive()-]
        public void NonActive()
        {
            IsActive = false;
            NonActiveDate = DateTime.Now;
        }
        #endregion

        #region [-Active()-]
        public void Active()
        {
            IsActive = true;
            ActiveDate = DateTime.Now;
        } 
        #endregion

    }
}
