using System.Collections.Generic;
using SchemeAuthApi.Controller;
using SchemeAuthApi.Error;
using SchemeAuthApi.Model;
using SchemeAuthApi.User.Dto;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SchemeAuthApi.User;
using Xunit;

namespace SchemeAuthApi.Tests.Controller
{
    public class UserControllerTests
    {
        private readonly Mock<IUserService> mockUserService;
        private readonly UserController userController;

        public UserControllerTests()
        {
            mockUserService = new Mock<IUserService>();
            userController = new UserController(mockUserService.Object);
        }

        [Fact(DisplayName = "Create user, happy path, endpoint calls user service and returns response")]
        public void CreateUser_CallsRepository()
        {
            var input = new NewUserRequest
            {
                Username = "user1",
                Email = "user1@email.com",
                FullName = "User One"
            };
            var expectedStatus = 201;
            var expected = new DetailResponse<UserResponse>
            {
                Status = 201,
                Detail = new UserResponse
                {
                    Username = "user1",
                    Email = "user1@email.com",
                    FullName = "User One"
                }
            };
            var convertedDto = new UserDto
            {
                Username = "user1",
                Email = "user1@email.com",
                FullName = "User One"
            };

            mockUserService.Setup(service => service.CreateUser(input))
                .ReturnsAsync(convertedDto);

            // act
            var actual = userController.RegisterUser(input).Result.Result as CreatedResult;

            // assert
            Assert.Equal(expected, actual?.Value);
            Assert.Equal(expectedStatus, actual?.StatusCode);
            mockUserService.Verify(service => service.CreateUser(input), Times.Once);
            mockUserService.VerifyNoOtherCalls();
        }
    }
}
