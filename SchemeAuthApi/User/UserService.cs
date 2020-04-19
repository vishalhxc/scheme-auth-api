using System.Threading.Tasks;
using SchemeAuthApi.Model;
using SchemeAuthApi.User.Dto;
using SchemeAuthApi.User.Repository;
using SchemeAuthApi.User.Identity;

namespace SchemeAuthApi.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IIdentityService _identityService;

        public UserService(
            IUserRepository userRepository,
            IIdentityService identityService)
        {
            _userRepository = userRepository;
            _identityService = identityService;
        }

        public async Task<UserDto> CreateUser(NewUserRequest newUserRequest)
        {
            var userDto = ConvertToUserDto(newUserRequest);
            await _identityService.RegisterUser(
                userDto, 
                newUserRequest.Password);
            return userDto;
        }

        private static UserDto ConvertToUserDto(NewUserRequest newUserRequest)
        {
            return new UserDto()
            {
                Username = newUserRequest.Username,
                Email = newUserRequest.Email,
                FullName = newUserRequest.FullName
            };
        }
    }
}