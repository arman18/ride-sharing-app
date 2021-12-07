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
        {
		    byte[] send_buffer = Encoding.ASCII.GetBytes(match.DriverName+","+match.RiderName);

            try
            {

                Program.socket.SendTo(send_buffer, Program.sending_end_point);
            }

            catch (Exception send_exception)
            {
                Console.WriteLine(" Exception {0}", send_exception.Message);
            }

            return Ok(match);
        }

    }
}




