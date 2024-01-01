using AutoMapper;
using Refah.Application.Abstracts.Services.User_Services;
using Refah.Application.Dtos.User_Dtos;
using Refah.Domain.Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Services.UserServices
{
    [ScopedService]
    public class GetUserService : IGetUserService
    {
        #region [-Fields-]
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        #endregion

        #region [-ctor-]
        public GetUserService(IMapper mapper, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.userRepository = userRepository;
        }
        #endregion

        #region [-GetByIdAsync(Guid id)-]
        public async Task<UserDto> GetByIdAsync(Guid id)
        {
            var user = await userRepository.GetByIdAsync(id);
            return mapper.Map<UserDto>(user);
        }
        #endregion

        #region [-GetByUserName(string userName)-]
        public async Task<UserDto> GetByUserName(string userName)
        {
            var users = await userRepository.GetByUserName(userName);
            return mapper.Map<UserDto>(users);
        } 
        #endregion

        #region [-GetListAsync()-]
        public async Task<List<UserDto>> GetListAsync()
        {
            var user = await userRepository.GetAllAsync();
            return mapper.Map<List<UserDto>>(user);
        } 
        #endregion
    }
}
