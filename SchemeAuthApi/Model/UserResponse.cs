﻿using System;
using SchemeAuthApi.User.Dto;

namespace SchemeAuthApi.Model
{
    public class UserResponse
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }

        public override bool Equals(object obj)
        {
            return obj is UserResponse dto &&
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
