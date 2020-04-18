using SchemeAuthApi.User.Dto;

namespace SchemeAuthApi.User.Repository
{
    public interface IUserRepository
    {
        UserDto AddUser(UserDto userDto);
    }
}
