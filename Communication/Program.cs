using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Microsoft.AspNetCore.Hosting;


namespace Communication
{
    class Program
    {
        public static Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        public static IPAddress send_to_address = IPAddress.Parse("0.0.0.0");

        public static IPEndPoint sending_end_point = new IPEndPoint(send_to_address, 11000);
        [Obsolete]
        static void Main(string[] args)
        {
            

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
                        options.Listen(IPAddress.Parse("0.0.0.0"), 5002);
                        //options.Listen(IPAddress.Any, 443, listenOptions =>
                        //{
                        //    listenOptions.UseHttps(certificatePath, certificatePassword);
                        //} );
                    })
                    //  .UseUrls("https://*:5002")
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
