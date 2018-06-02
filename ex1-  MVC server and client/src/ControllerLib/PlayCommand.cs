using System;
using System.Net.Sockets;
using ModelLib;
using System.IO;
using ClientLib;

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
            Tuple<ClientOfServer, PlayerDirection> otherPlayerInfo = model.Play(args[0], client);
            ClientOfServer otherPlayer = otherPlayerInfo.Item1;
            //using (NetworkStream stream = otherPlayer.GetStream())
            //using (StreamWriter writer = new StreamWriter(stream))
            //{
            //    writer.AutoFlush = true;
            //    writer.Write(otherPlayerInfo.Item2.ToJSON());
            //}
            otherPlayer.WriteToClient(otherPlayerInfo.Item2.ToJSON());
            return null;
        }
    }
}
