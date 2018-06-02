using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using ModelLib;
using System.Threading;
using ClientLib;

namespace ControllerLib
{
    /// <summary>
    /// define start command
    /// </summary>
    /// <seealso cref="ControllerLib.MultiCommand" />
    class StartCommand : MultiCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StartCommand"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public StartCommand(IModel model) : base(model)
        {
        }

        /// <summary>
        /// Executes the specified arguments the start command.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="ch">The ch.</param>
        /// <param name="client">The client.</param>
        /// <returns>string of json</returns>
        public override string Execute(string[] args, ClientOfServer client = null)
        {
            string name = args[0];
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);
            model.Start(name, rows, cols,client);
            while (!model.IsPair(name)) {
                Thread.Sleep(2000);
            }
            return model.GetMaze(name).ToJSON();
        }
    }
}
