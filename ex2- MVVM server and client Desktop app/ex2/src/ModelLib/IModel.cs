using ClientLib;
using MazeLib;
using SearchAlgorithmsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    /// <summary>
    /// intrtface of model in the mvc
    /// </summary>
    public interface IModel
    {
        /// <summary>
        /// Generates the maze.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="cols">The cols.</param>
        /// <returns></returns>
        Maze GenerateMaze(string name, int rows, int cols);

        /// <summary>
        /// Solves the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="typeOfSolve">The type of solve.</param>
        /// <returns>the maze solution</returns>
        MazeSolution Solve(string name, int typeOfSolve);

        /// <summary>
        /// Starts the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="cols">The cols.</param>
        /// <param name="host">The host.</param>
        void Start(string name, int rows, int cols, ClientOfServer host);

        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <returns></returns>
        List<string> List();

        /// <summary>
        /// Joins the specified player.
        /// </summary>
        /// <param name="name">The name - the maze.</param>
        /// <param name="guest">The guest the client.</param>
        /// <returns>the current maze</returns>
        Maze Join(string name, ClientOfServer guest);

        /// <summary>
        /// Plays the maze.
        /// </summary>
        /// <param name="move">The move.</param>
        /// <param name="player">The player.</param>
        /// <returns></returns>
        Tuple<ClientOfServer, PlayerDirection> Play(Direction move, ClientOfServer player);

        /// <summary>
        /// Closes the specified TcpClient.
        /// </summary>
        /// <param name="player">The Tcp Client of the player.</param>
        /// <param name="name">The name of maze.</param>
        /// <returns>>The Tcp Client of the other player.</returns>
        ClientOfServer Close(string name, ClientOfServer player);

        /// <summary>
        /// Determines whether the  name is pair.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        ///   <c>true</c> if the specified name is pair; otherwise, <c>false</c>.
        /// </returns>
        bool IsPair(string name);

        /// <summary>
        /// Gets the maze.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        Maze GetMaze(string name);

    }
}
