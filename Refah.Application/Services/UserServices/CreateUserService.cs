using AutoMapper;
using Refah.Application.Abstracts.Services.User_Services;
using Refah.Application.Contract.Operation;
using Refah.Application.Dtos.User_Dtos;
using Refah.Domain.Aggregates;
using Refah.Domain.Factories;
using Refah.Domain.Repositories;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace Refah.Application.Services.UserServices
{
    [ScopedService]
    public class CreateUserService : ICreateUserService
    {
        #region [-Fields-]
        private readonly IUserRepository userRepository;
        private readonly UserFactoryService userFactoryService;
        private readonly IMapper mapper;
        #endregion

        #region [-ctor-]
        public CreateUserService(IUserRepository userRepository,
                                 UserFactoryService userFactoryService,
                                 IMapper mapper)
        {
            this.userRepository = userRepository;
            this.userFactoryService = userFactoryService;
            this.mapper = mapper;
        }
        #endregion

        #region [-CreateAsync(CreateOrUpdateUser input)-]
        public async Task<OperationResult> CreateAsync(CreateOrUpdateUser input)
        {
            var operation = new OperationResult();

            var user = new CustomUser(input.FName,
                                               input.LName,
                                               input.UserName,
                                               input.Password,
                                               input.Email);

            await userRepository.InsertAsync(user);
            return operation.Succedded(ApplicationMessages.Succeded);
        }
        #endregion

        #region [-CreateByUserNameAsync(CreateOrUpdateUser input)-]
        public async Task<UserDto> CreateByUserNameAsync(CreateOrUpdateUser input)
        {
            var user = await userFactoryService.CreateAsync(input.FName,
                                               input.LName,
                                               input.UserName,
                                               input.Password,
                                               input.Email);
            return mapper.Map<CustomUser, UserDto>(user);
        } 
        #endregion

    }
}
