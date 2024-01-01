using Refah.Application.Contract.Operation;
using Refah.Application.Dtos.User_Dtos;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Abstracts.Services.User_Services
{
    [ScopedService]
    public interface IUpdateUserService
    {
        Task<OperationResult> UpdateAsync(Guid id, CreateOrUpdateUser input);
    }
}
