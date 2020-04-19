using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SchemeAuthApi.User.Dto;
using SchemeAuthApi.User.Entity;

namespace SchemeAuthApi.User.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<UserEntity> _userManager;

        public IdentityService(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserDto> RegisterUser(UserDto userDto, string password)
        {
            var result = await _userManager.CreateAsync(
                ConvertToUserEntity(userDto), 
                password); 
            
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.ToString());
            }            
            
            return userDto;
        }

        private static UserEntity ConvertToUserEntity(UserDto userDto)
        {
            return new UserEntity
            {
                UserName = userDto.Username,
                Email = userDto.Email,
                FullName = userDto.FullName
            };
        }
    }
}