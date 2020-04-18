using Microsoft.AspNetCore.Identity;

namespace SchemeAuthApi.User.Entity
{
    public class UserRoleEntity : IdentityRole<string>
    {
        public UserRoleEntity() {}

        public UserRoleEntity(string name)
        {
            Name = name;
        }
    }
}