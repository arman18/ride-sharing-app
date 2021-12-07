using System;
using System.Collections.Generic;
using System.Text;

namespace rideServer.Models
{
    public class Rider
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public string Destination { get; set; }

        public string toString()
        {
            return "Name: " + Name + " Position: " + Position + " Destination: " + Destination +"\n";
        }
    }
    
}
