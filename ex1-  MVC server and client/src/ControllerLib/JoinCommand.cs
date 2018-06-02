using System.Net.Sockets;
using ModelLib;
using MazeLib;
using ClientLib;

namespace ControllerLib
{
    /// <summary>
    /// define join command
    /// </summary>
    /// <seealso cref="ControllerLib.MultiCommand" />
    class JoinCommand : MultiCommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JoinCommand"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public JoinCommand(IModel model) : base(model)
        {
        }

        /// <summary>
        /// Executes the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="ch">The ch.</param>
        /// <param name="client">The client.</param>
        /// <returns>string of the join command</returns>
        public override string Execute(string[] args, ClientOfServer client = null)
        {
            string name = args[0];
            Maze maze = model.Join(name,client);
            return maze.ToJSON();
        }
    }
}
