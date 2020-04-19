using System;
using System.Collections.Generic;
using SchemeAuthApi.Data;
using SchemeAuthApi.Error;
using SchemeAuthApi.User.Dto;
using SchemeAuthApi.User.Entity;
using SchemeAuthApi.User.Repository;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace SchemeAuthApi.Tests.User.Repository
{
    public class UserRepositoryTests : IDisposable
    {
        private readonly AuthDbContext testContext;
        private readonly IUserRepository userRepository;

        public UserRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AuthDbContext>()
                .UseInMemoryDatabase("scheme_auth_in_memory")
                .Options;
            testContext = new AuthDbContext(options);
            userRepository = new UserRepository(testContext);
        }
        
        public void Dispose()
        {
            testContext.Dispose();
        }
    }
}