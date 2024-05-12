using Coffee.Domain.Models;
using Coffee.Infrastructure.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee_Infrastructure_Test.Services
{
    public class CoffeeService_Test
    {

        [Fact]
        public async Task NormalBehaviorTest()
        {
            // Arrange
            var service = new CoffeeService();

            CoffeeService.getRequestCount = 1; 
            
            // Act
            var result = await service.BrewCoffeeAsync();

            var valueString = result.Item2.ToString();

            var valueObject = JObject.Parse(valueString);

            var message = valueObject["message"].ToString();

            // Assert
            Assert.Equal("Your piping hot coffee is ready", message);

        }

        [Fact]
        public async Task ServiceUnavailableTest()
        {
            // Arrange
            var service = new CoffeeService();
            CoffeeService.getRequestCount = 4; // Set getRequestCount to 5, to ensure it's the fifth call

            // Act
            var result = await service.BrewCoffeeAsync();

            // Assert
            Assert.Equal((CoffeeStatus.ServiceUnavailable, ""), result);
        }

        

        //[Fact]
        //public async Task Returns418ImATeapotTest()
        //{

        //    // Arrange
        //    var service = new CoffeeService();

        //    var originalToday = System.DateTime.Today;

        //    System.DateTime aprilFirst = new System.DateTime(2024, 4, 1);

        //    System.DateTime today = aprilFirst;

        //        // Act
        //        var result = await service.BrewCoffeeAsync();

        //        // Assert
        //        Assert.Equal((CoffeeStatus.ImATeapot, "418 I'm a teapot"), result);

        //}


    }
}
