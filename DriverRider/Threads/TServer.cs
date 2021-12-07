using rideServer.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace rideServer.Threads
{
    class TServer
    {
        private static List<Driver> drivers=new List<Driver>();
        private static List<Rider> riders = new List<Rider>();
        public async void run()
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(5000);
                    if(riders.Count >0 && drivers.Count>0) matchPair();
                }
                
            });
           
        }

        public static void matchPair()
        {
            List<Rider> tempRiders = riders;
            List<Driver> tempDrivers = drivers;
            double tempMinDist = double.MaxValue;
            Driver tempDriver = null;
            foreach (Rider rider in tempRiders)
            {
                tempMinDist = double.MaxValue;
                tempDriver = null;
                int x1, y1, x2, y2;
                string[] x1y1 = rider.Position.Split(',');
                x1 = Int32.Parse(x1y1[0]);
                y1 = Int32.Parse(x1y1[1]);
                if (tempRiders.Count == 0) continue;
                for (int i = 0; i < tempDrivers.Count; i++)
                {
                    x1y1 = tempDrivers[i].Position.Split(',');
                    x2 = Int32.Parse(x1y1[0]);
                    y2 = Int32.Parse(x1y1[1]);
                    double distance = Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
                    if (distance < tempMinDist)
                    {
                        tempMinDist = distance;
                        tempDriver = tempDrivers[i];
                    }
                }
                //-------------
                //Console.WriteLine(tempDriver.toString());
                //Console.WriteLine(rider.toString());
                //----------
                
                tempDrivers.Remove(tempDriver);
                drivers.Remove(tempDriver);

                var client = new WebClient();
                client.Headers[HttpRequestHeader.ContentType] = "application/json"; //http://127.0.0.1:5002/api/match
                client.UploadString("http://communication-dhaka:8080/api/match", "{\"DriverName\":\""+tempDriver.Name+"\",\"DriverLocation\":\""+ tempDriver.Position + "\",\"RiderName\":\""+ rider.Name + "\",\"RiderLocation\":\""+ rider.Position + "\"}");

            }
            for (int i = 0; i < tempRiders.Count; i++)
            {
                riders.Remove(tempRiders[i]);
            }
            //---------
            /*Console.WriteLine(drivers.Count);
            Console.WriteLine(riders.Count);*/
            //------
            return ;

        }
        public static bool AddDriver(Driver driver)
        {
            
            for (int i = 0; i < drivers.Count; i++)
            {
                if (drivers[i].Name == driver.Name &&
                    drivers[i].CarName == driver.CarName)
                {
                    drivers[i].Position = driver.Position;
                    return true;
                }
                    
            }
            drivers.Add(driver);
            return true;
        }
        public static bool AddRider(Rider rider){

            riders.Add(rider);
            return true;
        }
    }
}
