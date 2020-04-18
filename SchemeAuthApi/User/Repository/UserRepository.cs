using System.Collections.Generic;
using System.Linq;
using SchemeAuthApi.Data;
using SchemeAuthApi.Error;
using SchemeAuthApi.User.Dto;
using SchemeAuthApi.User.Entity;

namespace SchemeAuthApi.User.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthDbContext _context;
        public UserRepository(AuthDbContext context)
        {
            _context = context;
        }

        public UserDto AddUser(UserDto userDto)
        {
            ValidateUser(userDto.Username, userDto.Email);
            return ConvertToDto(
                SaveUser(ConvertToEntity(userDto)));
        }

        private List<UserEntity> GetUser(string username, string email)
        {
            return _context.Users.Where(
                u => u.UserName == username ||
                u.Email == email).ToList();
        }

        private UserEntity SaveUser(UserEntity userEntity)
        {
            var entity = _context.Users.Add(userEntity)
                .Entity;
            _context.SaveChanges();
            return entity;
        }

        private void ValidateUser(string username, string email)
        {
            var users = GetUser(username, email);
            if (!users.Any()) return;

            var errorMessages = new List<string>();
            users.ForEach(u =>
            {
                if (u.UserName == username)
                    errorMessages.Add(ErrorConstants.UsernameAlreadyExists);
                if (u.Email == email)
                    errorMessages.Add(ErrorConstants.EmailAlreadyExists);
            });
            throw new ConflictException(errorMessages);
        }

        private UserEntity ConvertToEntity(UserDto userDto)
        {
            return new UserEntity
            {
                UserName = userDto.Username,
                Email = userDto.Email,
                FullName = userDto.FullName
            };
        }

        private UserDto ConvertToDto(UserEntity userEntity)
        {
            return new UserDto
            {
                Username = userEntity.UserName,
                Email = userEntity.Email,
                FullName = userEntity.FullName
            };
        }
    }
}
