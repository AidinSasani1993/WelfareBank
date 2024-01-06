using Refah.Application.Dtos.User_Dtos;
using Refah.Domain.Entities;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Abstracts.Services.User_Services
{
    [ScopedService]
    public interface IGetUserService
    {
        Task<UserDto> GetByUserName(string userName);
        Task<UserDto> GetByIdAsync(Guid id);
        Task<List<UserDto>> GetListAsync();
    }
}
