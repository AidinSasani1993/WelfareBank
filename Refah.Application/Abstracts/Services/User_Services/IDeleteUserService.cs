using Refah.Application.Contract.Operation;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Abstracts.Services.User_Services
{
    [ScopedService]
    public interface IDeleteUserService
    {
        Task<OperationResult> RemoveAsync(Guid id);
    }
}
