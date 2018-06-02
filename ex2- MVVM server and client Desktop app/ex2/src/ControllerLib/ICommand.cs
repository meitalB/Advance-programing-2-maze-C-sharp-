using ClientLib;
using System;
using System.Net.Sockets;

namespace ControllerLib
{
    /// <summary>
    /// icommand is the interface 
    /// </summary>
    interface ICommand
    {
        /// <summary>
        /// Executes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="ch">The ch.</param>
        /// <param name="client">The client.</param>
        /// <returns>string of the command</returns>
        string Execute(string[] args, ClientOfServer client = null);
    }
}
