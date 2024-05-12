using Coffee.Domain.Models;
using Coffee.Domain.Services;
using Coffee.Infrastructure.Services;
using Coffee_API.Controllers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Coffee_API_Test.Controllers
{

    public class CoffeeController_Test
    {
        [Fact]
        public async Task BrewCoffee_ReturnsOk_Test()
        {
            // Arrange
            var coffeeServiceMock = new Mock<ICoffeeService>();
            coffeeServiceMock.Setup(x => x.BrewCoffeeAsync()).ReturnsAsync((CoffeeStatus.OK, "Your piping hot coffee is ready"));

            var controller = new CoffeeController(coffeeServiceMock.Object);

            // Act
            var result = await controller.BrewCoffee();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal("Your piping hot coffee is ready", okResult.Value);

        }
        [Fact]
        public async Task BrewCoffee_Returns500StatusCode_Test()
        {
            // Arrange
            var coffeeServiceMock = new Mock<ICoffeeService>();
            coffeeServiceMock.Setup(x => x.BrewCoffeeAsync()).ThrowsAsync(new Exception());

            var controller = new CoffeeController(coffeeServiceMock.Object);

            // Act
            var result = await controller.BrewCoffee();

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var objectResult = result as StatusCodeResult;
            Assert.Equal(500, objectResult.StatusCode);
        }
        [Fact]
        public async Task BrewCoffee_ReturnsImATeapot_Test()
        {
            // Arrange
            var coffeeServiceMock = new Mock<ICoffeeService>();
            coffeeServiceMock.Setup(x => x.BrewCoffeeAsync()).ReturnsAsync((CoffeeStatus.ImATeapot,null));

            var controller = new CoffeeController(coffeeServiceMock.Object);

            // Act
            var result = await controller.BrewCoffee();

            // Assert
            Assert.IsType<ObjectResult>(result);
            var objectResult = result as ObjectResult;
            Assert.Equal(418,objectResult.StatusCode);
            Assert.Null(objectResult.Value);
        }

    }
}
