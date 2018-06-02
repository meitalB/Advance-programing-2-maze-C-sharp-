using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelLib;
using Newtonsoft.Json;
using ClientLib;

namespace ControllerLib
{
    /// <summary>
    /// define list command 
    /// </summary>
    /// <seealso cref="ControllerLib.SingleCommand" />
    class ListCommand : SingleCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListCommand"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public ListCommand(IModel model) : base(model)
        {
        }

        /// <summary>
        /// Executes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="ch">The ch.</param>
        /// <param name="client">The client.</param>
        /// <returns>string of list command</returns>
        public override string Execute(string[] args, ClientOfServer client = null)
        {
            string list = JsonConvert.SerializeObject(model.List());
            client.WriteToClient(list);
            client.DisconnectFromServer();
            return list;
        }
    }
}
