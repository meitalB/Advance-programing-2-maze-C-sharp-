using MazeGeneratorLib;
using MazeLib;
using System;
using System.Collections.Generic;

namespace WebMaze.Models
{
    public class MultiPlayerModel : IMultiPlayerModel
    { 
       /// <param name="name">The name of maze.</param>
       /// <param name="rows">The rows of maze.</param>
       /// <param name="cols">The cols of maze.</param>
       /// <returns></returns>
        public Maze GenerateMaze(string name, int rows, int cols)
        {
            IMazeGenerator g = new DFSMazeGenerator();
            Maze maze = g.Generate(rows, cols);
            maze.Name = name;
            return maze;
        }
    }
}

/// <summary>
/// Generates the specified maze.
/// </summary>
