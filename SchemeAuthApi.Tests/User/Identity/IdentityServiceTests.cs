using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using SchemeAuthApi.User.Dto;
using SchemeAuthApi.User.Entity;
using SchemeAuthApi.User.Identity;
using Xunit;

namespace SchemeAuthApi.Tests.User.Identity
{
    public class IdentityServiceTests
    {
        private readonly Mock<MockUserManager> _mockUserManager;
        private readonly Mock<SignInManager<UserEntity>> _mockSignInManager;
        private readonly IdentityService _identityService;

        public IdentityServiceTests()
        {
            _mockUserManager = new Mock<MockUserManager>();
            _identityService = new IdentityService(_mockUserManager.Object, _mockSignInManager.Object);
        }
        
        [Fact(DisplayName = "Register user, happy path, returns Dto")]
        public void registerUser_HappyPath()
        {
            // var input = new UserDto
            // {
            //     Username = "user1",
            //     Email = "user1@email.com",
            //     FullName = "User One"
            // };
            // var expected = new UserDto
            // {
            //     Username = "user1",
            //     Email = "user1@email.com",
            //     FullName = "User One"
            // };
            // var inputPassword = "password";
            // var convertedEntity = new UserEntity
            // {
            //     UserName = "user1",
            //     Email = "user1@email.com",
            //     FullName = "User One"
            // };
            //
            // _mockUserManager.Setup(manager =>
            //         manager.CreateAsync(convertedEntity, inputPassword))
            //     .Returns(Task.FromResult(IdentityResult.Success));
            //
            // // act
            // var actual = _identityService.RegisterUser(input, inputPassword);
            //
            // // assert
            // Assert.Equal(expected, actual);
            //  _mockUserManager.Verify(manager =>
            //      manager.CreateAsync(convertedEntity, inputPassword), Times.Once);
            //  _mockUserManager.VerifyNoOtherCalls();
        }
    }
    
    public class MockUserManager : UserManager<UserEntity>
    {
        public MockUserManager()
            : base(
                new Mock<IUserStore<UserEntity>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<IPasswordHasher<UserEntity>>().Object,
                new IUserValidator<UserEntity>[0],
                new IPasswordValidator<UserEntity>[0],
                new Mock<ILookupNormalizer>().Object,
                new Mock<IdentityErrorDescriber>().Object,
                new Mock<IServiceProvider>().Object,
                new Mock<ILogger<UserManager<UserEntity>>>().Object)
        { }
    }

    // public class MockSignInManager : SignInManager<UserEntity>
    // {
    //     public MockSignInManager()
    //         : base()
    // }
}    