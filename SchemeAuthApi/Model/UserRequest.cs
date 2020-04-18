using System;
using System.ComponentModel.DataAnnotations;
using SchemeAuthApi.Error;
using SchemeAuthApi.User.Dto;

namespace SchemeAuthApi.Model
{
    public class UserRequest
    {
        [Required(ErrorMessage = ErrorConstants.UsernameIsRequired)]
        [StringLength(20, ErrorMessage = ErrorConstants.UsernameTooLong)]
        public string Username { get; set; }

        [Required(ErrorMessage = ErrorConstants.EmailIsRequired)]
        [StringLength(100, ErrorMessage = ErrorConstants.EmailTooLong)]
        public string Email { get; set; }

        [Required(ErrorMessage = ErrorConstants.FullNameIsRequired)]
        [StringLength(100, ErrorMessage = ErrorConstants.FullNameTooLong)]
        public string FullName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is UserDto dto &&
                   Username == dto.Username &&
                   Email == dto.Email &&
                   FullName == dto.FullName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Username, Email, FullName);
        }
    }
}
