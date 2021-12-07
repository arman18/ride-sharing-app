using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.AspNetCore.Hosting;
using rideServer.Models;
using rideServer.Threads;

namespace rideServer
{
    class Program
    {
        public static TcpListener serverSocket;
        [Obsolete]
        static void Main(string[] args)
        {
            TServer obj = new TServer();
            Thread thr = new Thread(new ThreadStart(obj.run));
            thr.Start();
            try
            {
                Console.WriteLine("starting rest api...!");
                //var certificatePath = Directory.GetCurrentDirectory() + @"\certificate\foxai.info.pfx"; ;
                //var certificatePassword = "pass123$";
                //IPAddress ipAddress = IPAddress.Parse("*");
                var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .UseKestrel(options =>
                    {
                        options.Listen(IPAddress.Parse("0.0.0.0"), 8080);
                        //options.Listen(IPAddress.Any, 443, listenOptions =>
                    })
                    .Build();

                host.Run();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // throw;
            }
        }
    }
}
