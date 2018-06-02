using System;
using System.Net.Sockets;
using ModelLib;
using System.IO;
using ClientLib;
using MazeLib;

namespace ControllerLib
{
    /// <summary>
    ///  define the command play
    /// </summary>
    /// <seealso cref="ControllerLib.MultiCommand" />
    class PlayCommand : MultiCommand
    {
        /// <summary>
        /// Initializes a new instance of the play command <see cref="PlayCommand"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public PlayCommand(IModel model) : base(model)
        {
        }

        public override string Execute(string[] args, ClientOfServer client = null)
        {
            Direction move = (Direction)Enum.Parse(typeof(Direction), args[0]);
            Tuple<ClientOfServer, PlayerDirection> otherPlayerInfo = model.Play(move, client);
            ClientOfServer otherPlayer = otherPlayerInfo.Item1;
            otherPlayer.WriteToClient(otherPlayerInfo.Item2.ToJSON());
            return null;
        }
    }
}
