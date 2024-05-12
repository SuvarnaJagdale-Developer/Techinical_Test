using Coffee.Domain.Models;
using Coffee.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Infrastructure.Services
{
    public class CoffeeService:ICoffeeService
    {
        public static int getRequestCount = 0;

        public  Task<(CoffeeStatus,string?)>BrewCoffeeAsync()
        {
            try
            {
                getRequestCount++;

                if (DateTime.Today.Month == 4 && DateTime.Today.Day == 1)
                     return Task.FromResult<(CoffeeStatus, string?)>((CoffeeStatus.ImATeapot,"418 I'm a teapot"));
               

                if (getRequestCount % 5 == 0)
                    return Task.FromResult<(CoffeeStatus, string?)>((CoffeeStatus.ServiceUnavailable,""));

                return Task.FromResult<(CoffeeStatus, string?)>((CoffeeStatus.OK, $"{{\n  \"message\": \"Your piping hot coffee is ready\",\n  \"prepared\": \"{DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:sszzz")}\" \n}}"));
               

            }
            catch (Exception ex)
            {
               return Task.FromResult<(CoffeeStatus, string?)>((CoffeeStatus.ServiceUnavailable, ex.Message));
            }
        }
    }

}
