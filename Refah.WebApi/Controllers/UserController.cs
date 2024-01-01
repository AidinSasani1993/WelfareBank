using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Refah.Application.Abstracts.Services.User_Services;
using Refah.Application.Contract.Operation;
using Refah.Application.Dtos.User_Dtos;

namespace Refah.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region [-Fields-]
        private readonly IGetUserService getUserService;
        private readonly ICreateUserService createUserService;
        private readonly IUpdateUserService updateUserService;
        private readonly IDeleteUserService deleteUserService; 
        #endregion

        #region [-ctor-]
        public UserController(IGetUserService getUserService,
                              ICreateUserService createUserService,
                              IUpdateUserService updateUserService,
                              IDeleteUserService deleteUserService)
        {
            this.getUserService = getUserService;
            this.createUserService = createUserService;
            this.updateUserService = updateUserService;
            this.deleteUserService = deleteUserService;
        }
        #endregion

        #region [-Actions-]

        #region [-GetByUserName(string userName)-]
        [HttpGet("{userName}")]
        [Authorize(Roles = "Admin")]
        public async Task<UserDto> GetByUserName(string userName)
        {
            return await getUserService.GetByUserName(userName);
        }
        #endregion

        #region [-CreateAsync(CreateOrUpdateUser input)-]
        [HttpPost]
        public async Task<OperationResult> CreateAsync(CreateOrUpdateUser input)
        {
            return await createUserService.CreateAsync(input);
        }
        #endregion

        #region [-UpdateAsync(Guid id, CreateOrUpdateUser input)-]
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<OperationResult> UpdateAsync(Guid id, CreateOrUpdateUser input)
        {
            return await updateUserService.UpdateAsync(id, input);
        }
        #endregion

        #region [-CreateByUserNameAsync(CreateOrUpdateUser input)-]
        [HttpPost("custom")]
        public async Task<UserDto> CreateByUserNameAsync(CreateOrUpdateUser input)
        {
            return await createUserService.CreateByUserNameAsync(input);
        }
        #endregion

        #region [-RemoveAsync(Guid id)-]
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<OperationResult> RemoveAsync(Guid id)
        {
            return await deleteUserService.RemoveAsync(id);
        }
        #endregion

        #endregion
    }
}
