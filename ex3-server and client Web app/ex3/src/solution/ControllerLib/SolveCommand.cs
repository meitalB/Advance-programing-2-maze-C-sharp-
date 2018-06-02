using ClientLib;
using MazeLib;
using ModelLib;
using Newtonsoft.Json;
using SearchAlgorithmsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLib
{
    /// <summary>
    /// define solve command
    /// </summary>
    /// <seealso cref="ControllerLib.SingleCommand" />
    class SolveCommand : SingleCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SolveCommand"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public SolveCommand(IModel model) : base(model)
        {
        }

        /// <summary>
        /// Executes the specified arguments to start.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="ch">The ch.</param>
        /// <param name="client">The client.</param>
        /// <returns>string of the solve maze</returns>
        public override string Execute(string[] args, ClientOfServer client = null)
        {
            string name = args[0];
            int typeSolve = int.Parse(args[1]);
            MazeSolution s = model.Solve(name, typeSolve);
            client.WriteToClient(s.ToJSON());
            client.DisconnectFromServer();
            return s.ToJSON();
        }
    }
}
