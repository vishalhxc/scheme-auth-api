using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using SchemeAuthApi.Error;

namespace SchemeAuthApi.User.Entity
{
    public class UserEntity: IdentityUser<string>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override string Id { get; set; }
        
        [Required]
        [PersonalData]
        [StringLength(100, ErrorMessage = ErrorConstants.FullNameTooLong)]
        [Column("full-name")]
        public string FullName { get; set; }
    }
}