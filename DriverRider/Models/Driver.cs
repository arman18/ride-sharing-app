using System;
using System.Collections.Generic;
using System.Text;

namespace rideServer.Models
{
    public class Driver
    {
        public string Name { get; set; }
        public string CarName { get; set; }

        public string Position { get; set; }

        public string toString()
        {
            return "name: " + Name + " Car Name: " + CarName + " Position: " + Position + "\n";
        }
    }
}
