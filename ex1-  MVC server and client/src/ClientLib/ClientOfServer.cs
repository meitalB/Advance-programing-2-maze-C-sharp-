using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib
{
    public class ClientOfServer : AbstractClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Client" /> class.
        /// </summary>
        /// <param name="tcpClient">The TCP client.</param>
        public ClientOfServer(TcpClient tcpClient)
        {
            this.tcpClient = tcpClient;
        }

        /// <summary>
        /// Disconnects from server.
        /// </summary>
        public void DisconnectFromServer()
        {
            WriteToClient("Disconnect");
        }

        /// <summary>
        /// Reads from client.
        /// </summary>
        /// <returns></returns>
        public string ReadFromClient()
        {
            string result;
            do
            {
                try
                {
                    if (Reader == null)
                    {
                        InitializeReader();
                    }
                    result = Reader.ReadLine();
                }

                // If the connection has been closed.
                catch (IOException)
                {
                    return "";
                }
            } while (string.IsNullOrEmpty(result));

            return result;
        }

        /// <summary>
        /// Writes to client.
        /// </summary>
        /// <param name="message">The message.</param>
        public void WriteToClient(string message)
        {
            try
            {
                if (Writer == null)
                {
                    InitializeWriter();
                }
                if (message != null)
                {
                    message = message.Replace(System.Environment.NewLine, "@");
                    Writer.WriteLine(message + Environment.NewLine);
                    Writer.Flush();
                }
            }

            // If the connection has been closed.
            catch (IOException) { }
        }
    }
}
