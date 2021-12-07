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

            _driverRiderRepository.Add(driverRider);
            return Ok(driverRider);
        }
    }
}
