using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using SchemeAuthApi.Error;
using SchemeAuthApi.User.Dto;
using SchemeAuthApi.User.Entity;

namespace SchemeAuthApi.User.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;

        public IdentityService(UserManager<UserEntity> userManager,
            SignInManager<UserEntity> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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

        public async Task SignInUser(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(
                username,
                password,
                true,
                false);

            if (!result.Succeeded)
            {
                throw new Exception(ErrorConstants.UsernamePasswordInvalid);
            }
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