using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCP_Serveri
{
    class Program
    {

        public static String ipAddress = "192.168.43.159";
        public static int port = 11000;

        public static object MessageBox { get; private set; }

        static void Main(string[] args)
        {

            Console.WriteLine("Do you want to connect ?(Y , N): ");
            String inputChoise = Console.ReadLine();
            if (inputChoise == "Y" || inputChoise == "y") {
                StartServer(ipAddress, port);
            }
            else {
                Console.WriteLine("Write IpAddress:");
                String ipAddress = Console.ReadLine();
                Console.WriteLine("Write Port:");
 Porti:
                try
                {
                    int port = Int32.Parse(Console.ReadLine());
                }
                catch (Exception e) {
                    Console.WriteLine("Porti duhet te jete numer!");
                    goto Porti;
                }

                StartServer(ipAddress, port);
            }

        }
        public static void StartServer(String IpAddr, int port)
        {
            // Get Host IP Address that is used to establish a connection  
            // In this case, we get one IP address of localhost that is IP : 127.0.0.1  
            // If a host has multiple addresses, you will get a list of addresses  
            IPHostEntry host = Dns.GetHostEntry(IpAddr);
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);


            try
            {

                // Create a Socket that will use Tcp protocol      
                System.Net.Sockets.Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                // A Socket must be associated with an endpoint using the Bind method  
                listener.Bind(localEndPoint);
                // Specify how many requests a Socket can listen before it gives Server busy response.  
                // We will listen 10 requests at a time  
                listener.Listen(10);

                Console.WriteLine("Waiting for a connection...");
                Socket handler = null;
                while (true)
                {
                    handler = listener.Accept();

                    // Incoming data from the client.    
                    string data = null;
                    byte[] bytes = null;
                    int bytesRec = 0;
                    while (true)
                    {
                        bytes = new byte[1024];
                        try
                        {
                            bytesRec = handler.Receive(bytes);
                        }
                        catch(Exception e)
                        {
                            Console.WriteLine(e.ToString());
                            handler.Close();
                        }

                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        Console.WriteLine("Text received : {0}", data);
                        
                        break;
                    }

                    String message = "Bravo jetmir";
                    handler.Send(Encoding.ASCII.GetBytes(message));


                    //byte[] msg = Encoding.ASCII.GetBytes(data);
                    //handler.Send(msg);
                }
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

            }

        }


    }
}
