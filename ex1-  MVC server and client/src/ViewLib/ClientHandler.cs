using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ControllerLib;

using ClientLib;

namespace ViewLib
{

    /// <summary>
    /// define a Client Handler 
    /// </summary>
    /// <seealso cref="ControllerLib.IClientHandler" />
    public class ClientHandler : IClientHandler
    {
        /// <summary>
        /// The controller - interface type
        /// </summary>
        IController controller;
        /// <summary>
        /// The run bool
        /// </summary>
        private bool run;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientHandler"/> class.
        /// </summary>
        /// <param name="c">The Controller.</param>
        public ClientHandler(IController c)
        {
            controller = c;
            run = true;
        }
        /// <summary>
        /// Handles the client.
        /// </summary>
        /// <param name="client">The client.</param>
        public void HandleClient(ClientOfServer client)
        {
            new Task(() => {
                while (client.IsConnected())
                {
                    // Receive the command from the client.
                    string commandLine = client.ReadFromClient();

                    if (!string.IsNullOrEmpty(commandLine))
                    {
                        Console.WriteLine("Received command: {0}", commandLine);

                        // Send the result to the client.
                        string result = controller.ExecuteCommand(commandLine, client);
                        client.WriteToClient(result);
                    }
                }
            }).Start();
        }
    }
}

//new Task(() =>
//{
//    JObject obj = new JObject();
//    obj["close"] = "game-over";

//    using (NetworkStream stream = client.GetStream())
//    using (StreamReader reader = new StreamReader(stream))
//    using (StreamWriter writer = new StreamWriter(stream))
//    {
//        while (run)
//        {
//            try
//            {
//                string commandLine = reader.ReadLine();
//                Console.WriteLine("Got command: {0}", commandLine);
//                string result = ExecuteCommand(commandLine, client);
//                if (result == obj.ToString()) { break; }
//                result = result.Replace(System.Environment.NewLine, "@");
//                result += System.Environment.NewLine;
//                writer.Flush();
//                writer.Write(result);
//            }
//            catch (Exception)
//            {
//                break;
//            }
//        }
//    }
//    client.Close();
//}).Start();

/// <summary>
/// Stops the connetion.
/// </summary>
//public void StopConnetion()
//{
//    run = false;
//}

/// <summary>
/// Executes the command.
/// </summary>
/// <param name="commandLine">The command line.</param>
/// <param name="client">The client.</param>
/// <returns></returns>
//private string ExecuteCommand(string commandLine, TcpClient client)
//{
//    return controller.ExecuteCommand(commandLine, client);
//}