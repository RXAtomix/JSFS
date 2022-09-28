using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public class Client
    {
        Socket sock;
        IPAddress address;
        int port;

        StreamReader input;
        string filename;

        public Client(IPAddress address, int port, string filename = null)
        {
            this.address = address;
            this.port = port;
            sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            if (filename != null)
                input = new StreamReader(filename);
        }

        public void Run()
        {
            try
            {
                sock.Connect(address, port);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                Environment.Exit(1);
            }
            string data = "";
            if (input != null)
            {

                data = input.ReadToEnd();
                byte[] dataArr = new byte[data.Length];
                //Encoding.UTF8.GetBytes can also be used but it only handle text files
                for (int i = 0; i < data.Length; ++i)
                   dataArr[i] = (byte)data[i];
                Console.WriteLine(dataArr.Length);
                sock.Send(dataArr);

            }
            else
                do
                {
                    data = Console.ReadLine();
                    if (data != null)
                        sock.Send(Encoding.UTF8.GetBytes(data + '\n'));
                } while (data != null);
        }
    }
}

