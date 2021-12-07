using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Communication.Models;
namespace Communication.Controllers
{
    public class API : Controller
    {


        [HttpPost("api/match")]
        public  IActionResult sendMatch([FromBody] Match match)
//        public  IActionResult sendMatch()
        {
	     byte[] send_buffer = Encoding.ASCII.GetBytes(match.DriverName+","+match.RiderName);
	    //Console.WriteLine("receiving api call------------!");
	    //byte[] msg = Encoding.ASCII.GetBytes("match.DriverName"+","+"match.RiderName");  
		    
            Program.handler.Send(send_buffer);  
            Console.WriteLine("buffer: "+send_buffer);
            Console.WriteLine("match.DriverName: "+match.DriverName+","+" match.RiderName: "+match.RiderName);

            return Ok(match);
        }

    }
}




