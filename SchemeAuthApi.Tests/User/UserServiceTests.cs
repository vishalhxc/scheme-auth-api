using System.Collections.Generic;
using SchemeAuthApi.Error;
using SchemeAuthApi.Model;
using SchemeAuthApi.User.Dto;
using SchemeAuthApi.User.Repository;
using Moq;
using SchemeAuthApi.User;
using SchemeAuthApi.User.Identity;
using Xunit;

namespace SchemeAuthApi.Tests.User
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly Mock<IIdentityService> _mockIdentityService;
        private readonly UserService _userService; 

        public UserServiceTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _mockIdentityService = new Mock<IIdentityService>();
            _userService = new UserService(_mockUserRepository.Object, _mockIdentityService.Object);
        }

        [Fact(DisplayName = "Create user, happy path, calls Identity")]
        public void CreateUser_CallsIdentity()
        {
            var input = new NewUserRequest
            {
                Username = "user1",
                Email = "user1@email.com",
                FullName = "User One"
            };
            var expected = new UserDto
            {
                Username = "user1",
                Email = "user1@email.com",
                FullName = "User One"
            };
            var convertedDto = new UserDto
            {
                Username = "user1",
                Email = "user1@email.com",
                FullName = "User One"
            };

            _mockIdentityService.Setup(identityService
                    => identityService.RegisterUser(convertedDto, input.Password))
                .ReturnsAsync(convertedDto);

            // act
            var actual = _userService.CreateUser(input).Result;

            // assert
            Assert.Equal(expected, actual);
            _mockIdentityService.Verify(identityService
                => identityService.RegisterUser(convertedDto, input.Password), Times.Once);
            _mockIdentityService.VerifyNoOtherCalls();
        }

        [Fact(DisplayName = "Create user, calls Identity, throws exception")]
        public void CreateUser_CallsIdentityAndThrowsException()
        {
            var input = new NewUserRequest
            {
                Username = "user1",
                Email = "user1@email.com",
                FullName = "User One"
            };
            var expected = new ConflictException(
                new List<string>() { ErrorConstants.UsernameAlreadyExists });
            var convertedDto = new UserDto
            {
                Username = "user1",
                Email = "user1@email.com",
                FullName = "User One"
            };

            _mockIdentityService.Setup(identityService
                    => identityService.RegisterUser(convertedDto, input.Password))
                .ThrowsAsync(expected);

            // act
            var actual = Assert.ThrowsAsync<ConflictException>(
                () => _userService.CreateUser(input)
            );

            // assert
            Assert.Equal(expected, actual.Result);
            _mockIdentityService.Verify(identityService
                => identityService.RegisterUser(convertedDto, input.Password), Times.Once);
            _mockIdentityService.VerifyNoOtherCalls();
        }
    }
}
