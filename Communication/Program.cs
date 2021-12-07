using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Microsoft.AspNetCore.Hosting;
using System.Text;
using System.Threading.Tasks;
namespace Communication
{


    class Program
    {
    
        public static async void wait(){
        await Task.Run(() =>{
        Console.WriteLine("Waiting for a connection...");  
      	handler = listener.Accept();
            
        });
    	              
    }

	public static Socket listener;
	public static Socket handler;
        [Obsolete]
        static void Main(string[] args)
        {
            
            IPAddress ipAddress = IPAddress.Parse("0.0.0.0");  
        	IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 1100);
            
            try {   
     
            listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);  
    
            listener.Bind(localEndPoint);  


            listener.Listen(10);  
  	    wait();
  
            
            //handler.Shutdown(SocketShutdown.Both);  
            //handler.Close();  
        }  
        catch (Exception e)  
        {  
            Console.WriteLine("arman"+e.ToString());  
        }

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
