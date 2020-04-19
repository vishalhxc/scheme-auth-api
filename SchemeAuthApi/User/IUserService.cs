using System.Threading.Tasks;
using SchemeAuthApi.Model;
using SchemeAuthApi.User.Dto;

namespace SchemeAuthApi.User
{
    public interface IUserService
    {
        public Task<UserDto> CreateUser(NewUserRequest newUserRequest);
    }
}