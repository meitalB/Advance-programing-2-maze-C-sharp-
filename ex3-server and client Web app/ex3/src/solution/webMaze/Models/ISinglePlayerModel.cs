//using ClientLib;
using MazeLib;
using SearchAlgorithmsLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WebMaze.Models
{
    /// <summary>
    /// intrtface of model in the mvc
    /// </summary>
    public interface ISinglePlayerModel
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
    }
}
