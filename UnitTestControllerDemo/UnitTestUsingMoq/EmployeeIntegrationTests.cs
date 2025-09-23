using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestControllerDemo.Controllers;
using UnitTestControllerDemo.Data;
using UnitTestControllerDemo.Models;

namespace UnitTestUsingMoq
{
    public class EmployeeIntegrationTests
    {
        [Fact]
        public void testAddUser()
        {
            //Arrange
            var inputUser = new User { Id = 2 ,Name="Bob"};

            var options = new DbContextOptionsBuilder<UserDbContext>()                
                //.UseInMemoryDatabase(databaseName:"UserDb")
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UserDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;")
                .Options;

            var dbCtx = new UserDbContext(options);

            var repos = new UserRepository(dbCtx);
            var controller = new UsersController(repos);

            //Act
            var result = controller.Post(inputUser);

            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
    }
}
