using System;
using System.Net;

namespace Server
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Server server = null;
            if (args.Length == 2 || args.Length == 1) 
            {
                int port;
                if (Int32.TryParse (args [0], out port) && port >= IPEndPoint.MinPort
                    && port <= IPEndPoint.MaxPort)
                    if (args.Length == 2)
                        server = new Server (port, args [1]);
                    else
                        server = new Server (port);
                else 
                {
                    Console.Error.WriteLine ("Port {0} is invalid", args[0]);
                    Environment.Exit (1);
                }
            } 
            else
            {
                Console.WriteLine("{0}: Usage port [file]", System.AppDomain.CurrentDomain.FriendlyName);
                System.Environment.Exit(1);
            }
            server.Run();
            System.Environment.Exit(0);
        }
    }
}
