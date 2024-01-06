using Refah.Domain.Entities;
using Refah.Domain.Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Domain.Factories
{
    [ScopedService]
    public class UserFactoryService
    {
        private readonly IUserRepository userRepository;

        #region [-ctor-]
        public UserFactoryService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        #endregion

        #region [-CreateAsync(string fName, string lName, string userName, string password, string email)-]
        public async Task<CustomUser> CreateAsync(string fName, string lName, string userName, string password, string email)
        {
            var existUser = await userRepository.GetByUserName(userName);

            if (existUser == null)
            {
                return new CustomUser(fName, lName, userName, password, email);
            }
            else
            {
                return null;
            }
        } 
        #endregion

    }
}
