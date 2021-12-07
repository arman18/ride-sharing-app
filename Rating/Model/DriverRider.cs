using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ServerApp.Model
{
    public class DriverRider
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Driver { get; set; }
        public string Rider { get; set; }
        public int Rating { get; set; }
    }
}
