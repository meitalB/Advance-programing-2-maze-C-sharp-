using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib
{
    /// <summary>
    /// Class AbstractClient.
    /// </summary>
    public abstract class AbstractClient
    {
        /// <summary>
        /// The jobj
        /// </summary>
        protected JObject Jobj;

        /// <summary>
        /// The TCP client
        /// </summary>
        protected TcpClient tcpClient;

        /// <summary>
        /// The reader
        /// </summary>
        public StreamReader Reader;

        /// <summary>
        /// The writer
        /// </summary>
        public StreamWriter Writer;

        /// <summary>
        /// Closes this instance.
        /// </summary>
        public void Close()
        {
            tcpClient.Close();
        }

        /// <summary>
        /// Determines whether this client is connected.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </returns>
        public bool IsConnected()
        {
            return tcpClient.Connected;
        }

        /// <summary>
        /// Initializes the reader.
        /// </summary>
        public void InitializeReader()
        {
            Reader = new StreamReader(tcpClient.GetStream());
        }

        /// <summary>
        /// Initializes the writer.
        /// </summary>
        public void InitializeWriter()
        {
            Writer = new StreamWriter(tcpClient.GetStream());
        }

        /// <summary>
        /// Equalses the specified other.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public bool Equals(AbstractClient other)
        {
            return tcpClient == other.tcpClient;
        }
    }
}
