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
        public void CreateUser_CallsUserService()
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
        
        [Fact(DisplayName = "Sign in user, happy path, endpoint calls user service and returns response")]
        public void SignInUser_CallsUserService()
        {
            var input = new SignInUserRequest
            {
                Username = "user1",
                Password = "password"
            };
            var expectedStatus = 200;
            var expected = new DetailResponse<string>
            {
                Status = 200,
                Detail = "Successfully logged in"
            };

            // act
            var actual = userController.SignInUser(input).Result.Result as OkObjectResult;

            // assert
            Assert.Equal(expected, actual?.Value);
            Assert.Equal(expectedStatus, actual?.StatusCode);
            mockUserService.Verify(service => service.SignInUser(input.Username, input.Password));
            mockUserService.VerifyNoOtherCalls();
        }
    }
}
