using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Coffee.Domain.Models;

namespace Coffee.Domain.Services
{
    public interface ICoffeeService
    {
     public Task <(CoffeeStatus,string?)> BrewCoffeeAsync();
         
    }
}
