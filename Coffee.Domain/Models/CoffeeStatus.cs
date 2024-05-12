using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coffee.Domain.Models
{
    public enum CoffeeStatus
    {
       
        OK = 200,
        ServiceUnavailable = 503,
        ImATeapot = 418

    }
   
}
