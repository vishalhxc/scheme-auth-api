using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchemeAuthApi.User.Entity
{
    public class UserEntity
    {
        [Key]
        [StringLength(20)]
        [Column("username")]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        [Column("email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        [Column("full-name")]
        public string FullName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is UserEntity entity &&
                   Username == entity.Username &&
                   Email == entity.Email &&
                   FullName == entity.FullName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Username, Email, FullName);
        }
    }
}
