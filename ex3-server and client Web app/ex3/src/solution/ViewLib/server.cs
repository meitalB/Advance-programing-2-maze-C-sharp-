using ClientLib;
using ControllerLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ViewLib
{
    public class Server
    {
        /// <summary>
        /// The port
        /// </summary>
        private int port;
        /// <summary>
        /// The listener Tcp listener
        /// </summary>
        private TcpListener listener;
        /// <summary>
        /// The instance of interface to handel the clients
        /// </summary>
        private IClientHandler ch;
        public Server(int port, IClientHandler ch)
        {
            this.port = port;
            this.ch = ch;
        }
        /// <summary>
        /// Starts this server.
        /// </summary>
        public void Start()
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            listener = new TcpListener(ep);

            listener.Start();
            Console.WriteLine("Waiting for connections...");

            Task task = new Task(() =>
            {
                while (true)
                {
                    try
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        Console.WriteLine("Got new connection");
                        ch.HandleClient(new ClientOfServer(client));
                    }
                    catch (SocketException)
                    {
                        break;
                    }
                }
                Console.WriteLine("Server stopped");
            });
            task.Start();
            task.Wait();
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            listener.Stop();
        }
    }
}
