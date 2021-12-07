using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rideServer.Models;
using rideServer.Threads;

namespace rideServer.Controllers
{
    public class API : Controller
    {
            

        [HttpPost("api/rider")]
        public  IActionResult PostRiderLocation([FromBody] Rider rider)
        {
            TServer.AddRider(rider);

            return Ok(rider);
        }

        [HttpPost("api/driver")]
        public IActionResult postDriverLocation([FromBody] Driver driver)
        {
            Console.WriteLine("working");
            TServer.AddDriver(driver);
            return Ok(driver);
        }
    }
}
