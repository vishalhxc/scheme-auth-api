using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SchemeAuthApi.Model;
using SchemeAuthApi.User.Dto;
using SchemeAuthApi.User;

namespace SchemeAuthApi.Controller
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<DetailResponse<UserResponse>>> RegisterUser(NewUserRequest newUser)
        {
            var userDto = await _userService.CreateUser(newUser);
            return Created("RegisterUser",
                new DetailResponse<UserResponse>
                {
                    Status = 201,
                    Detail = ConvertToUserResponse(userDto)
                });
        }

        private static UserResponse ConvertToUserResponse(UserDto userDto)
        {
            return new UserResponse
            {
                Username = userDto.Username,
                Email = userDto.Email,
                FullName = userDto.FullName
            };
        }
    }
}
