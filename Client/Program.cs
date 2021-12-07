//﻿#include <time.h>
//#include <stdlib.h>
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


public class UDPListener
{
    private const int listenPort = 1100;
    public static IPAddress ipAddress;
    public static    	IPEndPoint remoteEP;
    public static    	Socket sender;
public static    byte[] bytes = new byte[1024]; 
        public static async void post(string received_data){
    		await Task.Run(() =>{
    			string[] sp = received_data.Split(',');
			var client = new WebClient();
			int rating = 5;
			client.Headers[HttpRequestHeader.ContentType] = "application/json";
			string str = "{\"Driver\":"+ "\""+sp[0]+"\",\"Rider\":"+ "\""+sp[1]+"\",\"Rating\":"+ rating+"}";
			client.UploadString("http://localhost:8080/api/rating", str);
    		});
        }
    public static async void wait()
    {
      	ipAddress = IPAddress.Parse("0.0.0.0");  
        remoteEP = new IPEndPoint(ipAddress, 1100);
        sender = new Socket(ipAddress.AddressFamily,SocketType.Stream, ProtocolType.Tcp);
        sender.Connect(remoteEP);  
  
        Console.WriteLine("Socket connected to {0}",sender.RemoteEndPoint.ToString());

      	try {  
		await Task.Run(() =>{
		    while (true)
		    {
		        int bytesRec = sender.Receive(bytes);  
		        string received_data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
		        if(received_data=="") continue;
		        Console.WriteLine("received = {0}", received_data ); 
		        post(received_data);
		    }
		});   
	//        sender.Shutdown(SocketShutdown.Both);  
	//        sender.Close();  
  
            }  
            catch (ArgumentNullException ane)  
            {  
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());  
            }  
            catch (SocketException se)  
            {  
                Console.WriteLine("SocketException : {0}", se.ToString());  
            }  
            catch (Exception e)  
            {  
                Console.WriteLine("Unexpected exception : {0}", e.ToString());  
            }

    }
    public static int Main()
    {

        wait();
        string[] driver = new string[10];
        driver[0] = "{\"name\": \"driver1\",\"carName\": \"C1\",\"position\": \"0,0\"}";
        driver[1] = "{\"name\": \"driver2\",\"carName\": \"C2\",\"position\": \"20,0\"}";
        driver[2] = "{\"name\": \"driver3\",\"carName\": \"C3\",\"position\": \"50,0\"}";
        driver[3] = "{\"name\": \"driver4\",\"carName\": \"C4\",\"position\": \"0,30\"}";
        driver[4] = "{\"name\": \"driver5\",\"carName\": \"C5\",\"position\": \"0,10\"}";
        driver[5] = "{\"name\": \"driver6\",\"carName\": \"C6\",\"position\": \"70,0\"}";
        driver[6] = "{\"name\": \"driver7\",\"carName\": \"C7\",\"position\": \"20,30\"}";
        driver[7] = "{\"name\": \"driver8\",\"carName\": \"C8\",\"position\": \"30,10\"}";
        driver[8] = "{\"name\": \"driver9\",\"carName\": \"C9\",\"position\": \"10,40\"}";
        driver[9] = "{\"name\": \"driver10\",\"carName\": \"C10\",\"position\": \"20,50\"}";
        string[] rider = new string[10];
        rider[0] = "{\"name\": \"rider1\",\"position\": \"5,0\",\"destination\": \"17,34\"}";
        rider[1] = "{\"name\": \"rider2\",\"position\": \"5,60\",\"destination\": \"27,87\"}";
        rider[2] = "{\"name\": \"rider3\",\"position\": \"15,0\",\"destination\": \"37,65\"}";
        rider[3] = "{\"name\": \"rider4\",\"position\": \"25,30\",\"destination\": \"4,32\"}";
        rider[4] = "{\"name\": \"rider5\",\"position\": \"1,0\",\"destination\": \"47,75\"}";
        rider[5] = "{\"name\": \"rider6\",\"position\": \"10,20\",\"destination\": \"23,3\"}";
        rider[6] = "{\"name\": \"rider7\",\"position\": \"30,0\",\"destination\": \"45,43\"}";
        rider[7] = "{\"name\": \"rider8\",\"position\": \"20,50\",\"destination\": \"54,54\"}";
        rider[8] = "{\"name\": \"rider9\",\"position\": \"30,20\",\"destination\": \"65,32\"}";
        rider[9] = "{\"name\": \"rider10\",\"position\": \"15,10\",\"destination\": \"23,23\"}";
        var client = new WebClient();
        
        for(int i = 0; i < 10; i++)
        {
            Uri u1 = new Uri("http://localhost:8080/api/driver");
            Uri u2 = new Uri("http://localhost:8080/api/rider");
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.UploadString(u1, driver[i]);
            client.Headers[HttpRequestHeader.ContentType] = "application/json";
            client.UploadString(u2, rider[i]);
            
        }
	while(true){}
        return 0;
    }
}
