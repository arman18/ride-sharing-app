using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServerApp.Model;

namespace ServerApp.Repository
{
    public class DriverRiderRepository : DatabaseRepository
    {
        public DriverRider Add(DriverRider driverRider)
        {
            DatabaseContext.driverRiders.Add(driverRider);
            DatabaseContext.SaveChanges();
            return driverRider;
        }
    }
}
