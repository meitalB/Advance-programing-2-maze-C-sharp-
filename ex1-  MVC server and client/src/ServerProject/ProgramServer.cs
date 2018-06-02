using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ControllerLib;
using ModelLib;
using ViewLib;
using System.Configuration;

namespace ServerProject
{   /// <summary>
    /// this is the main of server
    /// </summary>
    class ProgramServer
    {
        static void Main(string[] args)
        {
            string ip = ConfigurationManager.AppSettings["IP"];
            string port = ConfigurationManager.AppSettings["Port"];
            Server server = new Server(int.Parse(port), new ClientHandler(new Controller(new ServerModel())));
            server.Start();
            Console.WriteLine("finish Server");
            Console.ReadLine();
        }
    }
}
