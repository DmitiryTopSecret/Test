using Microsoft.AspNetCore.Mvc;
using Moq;
using UserHandlerAPI.Controllers;
using UserHandlerAPI.DataAccess.Repository;
using UserHandlerAPI.Models;

namespace UserHadnlerAPI.Tests.Controller
{
    public class UserControllerTests
    {
        [Fact]
        public void GetAsync_ShouldReturn_200StatusCode()
        {
            // Arrange
            var repository = new Mock<IUserRepository>();

            var users = new List<User>
            {
                new User 
                { 
                    Id = 1, 
                    Name = "Name 1",
                    Email = "something@mail.com",
                    SubscriptionId= 1
                },
                new User
                {
                    Id = 2,
                    Name = "Name 2",
                    Email = "something@mail.com",
                    SubscriptionId= 1
                }
            };
            repository.Setup(r => r.GetUsers()).ReturnsAsync(users);

            var controller = new UserController(repository.Object);

            // Act
            var result = controller.GetUsers().GetAwaiter().GetResult();

            // Assert
            var actionResult = result.Result as OkObjectResult;

            Assert.IsType<OkObjectResult>(actionResult);

            Assert.Equal(200, actionResult.StatusCode);

            repository.Verify(r => r.GetUsers(), Times.Once);
        }
    }
}
