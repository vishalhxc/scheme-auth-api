using SchemeAuthApi.Model;
using SchemeAuthApi.User.Dto;
using SchemeAuthApi.User.Repository;

namespace SchemeAuthApi.User.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDto CreateUser(UserRequest userRequest)
        {
            return _userRepository.AddUser(ConvertRequestToDto(userRequest));
        }

        private UserDto ConvertRequestToDto(UserRequest userRequest)
        {
            return new UserDto
            {
                Username = userRequest.Username,
                Email = userRequest.Email,
                FullName = userRequest.FullName
            };
        }
    }
}