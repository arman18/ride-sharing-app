using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ServerApp.Model;
using ServerApp.Repository;

namespace ServerApp.Controllers
{
    public class DriverRiderController : Controller
    {
        private readonly DriverRiderRepository _driverRiderRepository = new DriverRiderRepository();

        [HttpPost("api/rating")]
        public IActionResult AddRating([FromBody] DriverRider driverRider)
        {
        	Console.WriteLine("Hello World!");
            Console.WriteLine(driverRider.Driver);
            _driverRiderRepository.Add(driverRider);
           	Console.WriteLine("Hello World!");
            return Ok(driverRider);
        }
    }
}
