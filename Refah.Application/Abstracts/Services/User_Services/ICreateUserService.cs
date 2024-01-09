using Refah.Application.Contract.Operation;
using Refah.Application.Dtos.User_Dtos;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Abstracts.Services.User_Services
{
    [ScopedService]
    public interface ICreateUserService
    {
        Task<OperationResult> CreateAsync(CreateOrUpdateUser input);
        //Task<UserDto> CreateByUserNameAsync(CreateOrUpdateUser input);
    }
}
