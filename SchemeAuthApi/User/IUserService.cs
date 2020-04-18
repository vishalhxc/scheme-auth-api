using SchemeAuthApi.Model;
using SchemeAuthApi.User.Dto;

namespace SchemeAuthApi.User.Service
{
    public interface IUserService
    {
        public UserDto CreateUser(UserRequest userRequest);
    }
}