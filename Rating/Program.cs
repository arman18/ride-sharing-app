using System;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Hosting;
namespace tryingToCopySir
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .UseKestrel(options =>
                    {
                        options.Listen(IPAddress.Parse("0.0.0.0"), 8080); // 172.0.0.1 IPAddress.Any

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
