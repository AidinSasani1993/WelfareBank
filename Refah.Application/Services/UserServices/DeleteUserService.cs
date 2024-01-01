using AutoMapper;
using Refah.Application.Abstracts.Services.User_Services;
using Refah.Application.Contract.Operation;
using Refah.Domain.Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Services.UserServices
{
    [ScopedService]
    public class DeleteUserService : IDeleteUserService
    {

        #region [-Fields-]
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        #endregion

        #region [-ctor-]
        public DeleteUserService(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }
        #endregion

        #region [-RemoveAsync(Guid id)-]
        public async Task<OperationResult> RemoveAsync(Guid id)
        {
            var operation = new OperationResult();

            var user = await userRepository.GetByIdAsync(id);

            await userRepository.UpdateAsync(user);

            return operation.Succedded(ApplicationMessages.Succeded);
        } 
        #endregion
    }
}
