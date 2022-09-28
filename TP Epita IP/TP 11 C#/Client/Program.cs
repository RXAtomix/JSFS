using System;
using System.Net;

namespace Client
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Client client = null;
            if (args.Length == 3 || args.Length == 2) 
            {
                IPAddress address;
                int port;
                if (!IPAddress.TryParse (args [0], out address)) 
                {
                    Console.Error.WriteLine ("IP Address {0} invalid", args [0]);
                    Environment.Exit (1);
                }
                else if (!Int32.TryParse (args [1], out port) || port < IPEndPoint.MinPort
                             || port > IPEndPoint.MaxPort)
                {
                    Console.Error.WriteLine ("Port {0} invalid", args [1]);
                    Environment.Exit (1);
                }
                else
                {
                    if (args.Length == 3)
                        client = new Client (System.Net.IPAddress.Parse (args [0]), Int32.Parse (args [1]), args [2]);
                    else
                        client = new Client (System.Net.IPAddress.Parse (args [0]), Int32.Parse (args [1]));
                    client.Run ();
                }
            }
            else
            {
                Console.WriteLine("{0}: Usage ip port [file]", System.AppDomain.CurrentDomain.FriendlyName);
                System.Environment.Exit(1);
            }
        }
    }
}
