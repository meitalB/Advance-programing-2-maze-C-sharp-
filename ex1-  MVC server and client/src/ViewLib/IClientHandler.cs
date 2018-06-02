using ClientLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ViewLib
{
    /// <summary>
    /// interface of the client handler
    /// </summary>
    public interface IClientHandler
    {
        /// <summary>
        /// Handles the client.
        /// </summary>
        /// <param name="client">The client.</param>
        void HandleClient(ClientOfServer client);
        /// <summary>
        /// Stops the connetion.
        /// </summary>
        //void StopConnetion();

    }
}
