using System.Collections.Generic;
using SchemeAuthApi.Error;
using SchemeAuthApi.Model;
using SchemeAuthApi.User.Dto;
using SchemeAuthApi.User.Repository;
using SchemeAuthApi.User.Service;
using Moq;
using Xunit;

namespace SchemeAuthApi.Tests.Service
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> mockUserRepository;
        private readonly UserService userService;

        public UserServiceTests()
        {
            mockUserRepository = new Mock<IUserRepository>();
            userService = new UserService(mockUserRepository.Object);
        }

        [Fact(DisplayName = "Create user, happy path, calls Repository")]
        public void CreateUser_CallsRepository()
        {
            var input = new UserRequest
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

            mockUserRepository.Setup(repo => repo.AddUser(convertedDto))
                .Returns(convertedDto);

            // act
            var actual = userService.CreateUser(input);

            // assert
            Assert.Equal(expected, actual);
            mockUserRepository.Verify(repo => repo.AddUser(convertedDto), Times.Once);
            mockUserRepository.VerifyNoOtherCalls();
        }

        [Fact(DisplayName = "Create user, calls Repository, throws exception")]
        public void CreateUser_CallsRepositoryAndThrowsException()
        {
            var input = new UserRequest
            {
                Username = "user2",
                Email = "user@email.com",
                FullName = "User Two"
            };
            var expected = new ConflictException(
                new List<string>() { ErrorConstants.UsernameAlreadyExists });

            var convertedDto = new UserDto
            {
                Username = "user2",
                Email = "user@email.com",
                FullName = "User Two"
            };
            mockUserRepository.Setup(repo => repo.AddUser(convertedDto))
                .Throws(expected);

            // act
            var actual = Assert.Throws<ConflictException>(
                () => userService.CreateUser(input)
            );

            // assert
            Assert.Equal(expected.Messages, actual.Messages);
            mockUserRepository.Verify(repo => repo.AddUser(convertedDto), Times.Once);
            mockUserRepository.VerifyNoOtherCalls();
        }
    }
}
