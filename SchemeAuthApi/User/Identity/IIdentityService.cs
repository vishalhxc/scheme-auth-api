using System.Threading.Tasks;
using SchemeAuthApi.User.Dto;

namespace SchemeAuthApi.User.Identity
{
    public interface IIdentityService
    {
        Task<UserDto> RegisterUser(UserDto userDto, string password);
        Task SignInUser(string username, string password);
    }
}