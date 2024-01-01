using Refah.Application.Abstracts.Services.User_Services;
using Refah.Application.Contract.Operation;
using Refah.Application.Dtos.User_Dtos;
using Refah.Domain.Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Services.UserServices
{
    [ScopedService]
    public class UpdateUserService : IUpdateUserService
    {
        #region [-Field-]
        private readonly IUserRepository userRepository;
        #endregion

        #region [-ctor-]
        public UpdateUserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        #endregion

        #region [-UpdateAsync(Guid id, CreateOrUpdateUser input)-]
        public async Task<OperationResult> UpdateAsync(Guid id, CreateOrUpdateUser input)
        {
            var operation = new OperationResult();
            var user = await userRepository.GetByIdAsync(id);

            //if (await userRepository.Exists(a => a.Id != id))
            //{
            //    return operation.NotFound(ApplicationMessages.RecordNotFound);
            //}

            user.Modify(input.FName, input.LName, input.UserName, input.Password, input.Email);
            await userRepository.UpdateAsync(user);
            return operation.Succedded(ApplicationMessages.Succeded);

        } 
        #endregion
    }
}
