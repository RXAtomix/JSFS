using System;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class Server
    {
        int port;
        Socket sock;
        StreamWriter output;


        public Server(int port, string filename = null)
        {
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this.port = port;
            if (filename != null)
                output = new StreamWriter(filename);
        }

        public void Run()
        {
            try
            {
                sock.Bind(new IPEndPoint(IPAddress.Any, port));
                sock.Listen(10);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                Environment.Exit(1);
            }

            while (true)
            {
                Socket clientSocket = sock.Accept();

                try 
                {
                    HandleClient(clientSocket);
                } 
                catch (SocketException e) 
                {
                    Console.Error.WriteLine(e.Message);
                }

                clientSocket.Close();
            }

        }

        private void HandleClient(Socket socket) 
        {
            int dataLength = 0;
            do {
                byte [] data = new byte [1024];
                dataLength = socket.Receive (data);

                for (int i = 0; i < dataLength; ++i)
                    if (output != null)
                        output.Write((char)data[i]);
                    else
                        Console.Write((char)data[i]);
                
            } while (dataLength > 0);

        }
    }
}

