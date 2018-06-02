using ClientLib;
using MazeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    /// <summary>
    /// multi player object info
    /// </summary>
    class MultiPlayerInfo
    {
        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>
        /// The host client.
        /// </value>
        public ClientOfServer Host
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the guest.
        /// </summary>
        /// <value>
        /// The guest.
        /// </value>
        public ClientOfServer Guest
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the maze.
        /// </summary>
        /// <value>
        /// The maze.
        /// </value>
        public Maze Maze
        {
            get; set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiPlayerInfo"/> class.
        /// </summary>
        public MultiPlayerInfo()
        {
            Host = null;
            Guest = null;
            Maze = null;
        }

        /// <summary>
        /// Gets the other player.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <returns>the tcp client</returns>
        /// <exception cref="System.Exception">the player does not exist</exception>
        public ClientOfServer GetTheOtherPlayer(ClientOfServer player)
        {
            if (Host.Equals(player))
            {
                return Guest;
            }

            if (Guest.Equals(player))
            {
                return Host;
            }

            throw new Exception("the player does not exist");
        }

        /// <summary>
        /// Contains the player.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <returns>bool if Contains player</returns>
        public bool ContainPlayer(ClientOfServer player)
        {
            if (Guest.Equals(player) || Host.Equals(player)) { return true; }
            return false;
        }
    }
}
