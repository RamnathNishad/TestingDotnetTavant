using Microsoft.AspNetCore.Mvc;
using Moq;
using UnitTestControllerDemo.Controllers;
using UnitTestControllerDemo.Data;
using UnitTestControllerDemo.Models;

namespace UnitTestUsingMoq
{
    public class UsersControllerTests
    {
        [Fact]
        public void GetById_ReturnsOk_WhenFound()
        {
            //Arrange
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(r => r.GetUserById(1)).Returns(new User { Id = 1, Name = "John" });

            var controller = new UsersController(mockRepo.Object);

            //Act
            var result = controller.Get(1);

            //Assert
            var ok=Assert.IsType<OkObjectResult>(result);
            var user = Assert.IsType<User>(ok.Value);

            Assert.Equal(1, user.Id);
            Assert.Equal("John", user.Name);
            Assert.Equal(200, ok.StatusCode); //valiate status code
        }

        [Fact]
        public void GetUserById_ReturnsNotFound()
        {
            //Arrange
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(r => r.GetUserById(2)).Returns((User)null);

            var controller = new UsersController(mockRepo.Object);

            //Act
            var result = controller.Get(2);

            //Assert
            Assert.IsType<NotFoundResult>(result);

        }

        [Fact]
        public void Post_ReturnsOk_WhenModelIsValid()
        {
            //Arrange
            var inputUser = new User { Id=1, Name="John" };
            var createdUser = new User { Id = 1, Name = "John" };
            var mockRepo=new Mock<IUserRepository>();
            mockRepo.Setup(r => r.AddUser(inputUser)).Returns(createdUser);

            var controller = new UsersController(mockRepo.Object);

            //Act
            var result = controller.Post(inputUser);

            //Assert
            var ok =Assert.IsType<OkObjectResult>(result);
            var u=Assert.IsType<User>(ok.Value);

            Assert.Equal(1, u.Id);
            Assert.Equal("John", u.Name);
        }

        [Fact]
        public void Post_ReturnsBadRequest_WhenModelIsInValid()
        {
            //Arrange
            var inputUser = new User { Id = 1 };
            var mockRepo = new Mock<IUserRepository>();
           
            var controller = new UsersController(mockRepo.Object);

            //Act
            var result = controller.Post(inputUser);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Put_ReturnsOk_WhenValid()
        {
            var inputUser = new User { Id = 1, Name = "David" };
            var updatedUser = new User { Id = 1, Name = "David" };
            var mockRepo=new Mock<IUserRepository>();
            mockRepo.Setup(r=>r.UpdateUser(inputUser)).Returns(updatedUser);

            var controller = new UsersController(mockRepo.Object);

            var result = controller.Put(1, inputUser);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void DeleteUser_ReturnsOk_WhenDeleted()
        {
            var user = new User { Id = 1, Name = "John" };
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(r => r.DeleteUser(1)).Returns(user);

            var controller = new UsersController(mockRepo.Object);


            var result = controller.Delete(1);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetUsers_Returns_NoContent()
        {
            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(r => r.GetAllUsers()).Returns((List<User>)null);

            var controller =new UsersController(mockRepo.Object);

            var result = controller.Get();
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void GetUsers_Returns_Ok()
        {
            var users = new List<User>
            {
                new User{Id=1,Name="John"},
                new User{Id=2,Name="Bob"},
                new User{Id=3,Name="David"}
            };

            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(r => r.GetAllUsers()).Returns(users);

            var controller = new UsersController(mockRepo.Object);

            var result = controller.Get();
            var ok =Assert.IsType<OkObjectResult>(result);
            var values = Assert.IsType<List<User>>(ok.Value);
            Assert.Equal(3, values.Count);
        }
    }
}