using System;
using System.ComponentModel.DataAnnotations;
using SchemeAuthApi.Error;

namespace SchemeAuthApi.Model
{
    public class SignInUserRequest
    {
        [Required(ErrorMessage = ErrorConstants.UsernameIsRequired)]
        [StringLength(20, ErrorMessage = ErrorConstants.UsernamePasswordInvalid)]
        public string Username { get; set; }
        
        [Required(ErrorMessage = ErrorConstants.PasswordIsRequired)]
        [StringLength(50, MinimumLength = 8, ErrorMessage = ErrorConstants.UsernamePasswordInvalid)]
        public string Password { get; set; }
        
        protected bool Equals(SignInUserRequest other)
        {
            return Username == other.Username && Password == other.Password;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SignInUserRequest) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Username, Password);
        }
    }
}