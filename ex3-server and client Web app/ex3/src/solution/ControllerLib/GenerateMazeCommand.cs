using MazeLib;
using System;
using System.Net.Sockets;
using ModelLib;
using ClientLib;

namespace ControllerLib
{
    /// <summary>
    /// Generate Maze Command 
    /// </summary>
    /// <seealso cref="ControllerLib.SingleCommand" />
    class GenerateMazeCommand : SingleCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenerateMazeCommand"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public GenerateMazeCommand(IModel model) : base(model)
        {
        }

        /// <summary>
        /// Executes the specified arguments Generate Maze Command.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="ch">The ch.</param>
        /// <param name="client">The client.</param>
        /// <returns></returns>
        public override string Execute(string[] args, ClientOfServer client = null)
        {
            string name = args[0];
            int rows = int.Parse(args[1]);
            int cols = int.Parse(args[2]);
            Maze maze = model.GenerateMaze(name, rows, cols);
            client.WriteToClient(maze.ToJSON());
            client.DisconnectFromServer();
            return maze.ToJSON();
        }
    }
}