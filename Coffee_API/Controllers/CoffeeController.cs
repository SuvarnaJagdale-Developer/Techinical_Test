using Coffee.Domain.Services;
using Coffee.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Coffee.Domain.Models;
using System.Net;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace Coffee_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {

        private readonly ICoffeeService _coffeeService;

        public CoffeeController(ICoffeeService coffeeService)
        {
            _coffeeService = coffeeService;
        }
        
        [HttpGet("brew-Coffee")]
        public async Task<ActionResult>BrewCoffee()
        {
            try
            {
                var (statusCode, responseBody) = await _coffeeService.BrewCoffeeAsync();
                if (statusCode == CoffeeStatus.OK)
                {
                    return Ok(responseBody);
                }
                else if (statusCode == CoffeeStatus.ServiceUnavailable)
                {
                    
                    return StatusCode((int)System.Net.HttpStatusCode.ServiceUnavailable,responseBody);

                }
                else if (statusCode == CoffeeStatus.ImATeapot)
                {
                        return StatusCode((int)CoffeeStatus.ImATeapot, responseBody);
     
                }
                else
                {
                  
                    return StatusCode((int)System.Net.HttpStatusCode.InternalServerError);
                }
            }catch (Exception ex) 
            { 
                return StatusCode(500); 
            }
            
        }
    }
}
