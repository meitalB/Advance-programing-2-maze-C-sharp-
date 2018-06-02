using MazeGeneratorLib;
using MazeLib;
using SearchAlgorithmsLib;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMaze.Models
{
    public class SinglePlayerModel : ISinglePlayerModel
    {
        private static ConcurrentDictionary<string, Maze> mazes = new ConcurrentDictionary<string, Maze>();
        private static ConcurrentDictionary<string, MazeSolution> solutionMazes = new ConcurrentDictionary<string, MazeSolution>();

        /// <summary>
        /// Generates the maze.
        /// </summary>
        /// <param name="name">The name of maze.</param>
        /// <param name="rows">The rows of maze.</param>
        /// <param name="cols">The cols of maze.</param>
        /// <returns>new maze as requserted</returns>
        public Maze GenerateMaze(string name, int rows, int cols)
        {
            if (mazes.ContainsKey(name))
                return mazes[name];
            Maze maze = Generate(name, rows, cols);
            mazes[name] = maze;
            return maze;
        }

        /// <summary>
        /// Solves the specified maze.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="typeOfSolve">The type of solve.</param>
        /// <returns>the solve of the maze</returns>
        /// <exception cref="System.Exception">This maze does not exist - " + name</exception>
        public MazeSolution Solve(string name, int typeOfSolve)
        {
            if (solutionMazes.ContainsKey(name))
            {
                return solutionMazes[name];
            }

            if (mazes.ContainsKey(name))
            {
                Maze maze = mazes[name];

                ObjectAdapter adapter = new ObjectAdapter(maze);

                BFS<Position, int> bfs = new BFS<Position, int>();
                DFS<Position, int> dfs = new DFS<Position, int>();
                switch (typeOfSolve)
                {
                    case 0:
                        return ConvertSolution(bfs.Search(adapter), maze.Name);
                    case 1:
                        return ConvertSolution(dfs.Search(adapter), maze.Name);
                    default:
                        throw new Exception("This search type does not exist - " + typeOfSolve);
                }
            }
            throw new Exception("This maze does not exist - " + name);
        }

        /// <summary>
        /// Converts the solution of maze.
        /// </summary>
        /// <param name="s">The solution of the maze.</param>
        /// <param name="name">The name of the maze.</param>
        /// <returns>the maze solution</returns>
        private MazeSolution ConvertSolution(Solution<Position, int> s, string name)
        {
            List<Position> positionList = new List<Position>();
            foreach (State<Position, int> state in s.GetSolution())
            {
                positionList.Add(state.StateValue);
            }

            MazeSolution ms = new MazeSolution()
            {
                EvaluatedNodes = s.GetEvaluatedNodes(),
                Solution = positionList,
                GameName = name
            };
            solutionMazes[name] = ms;
            return ms;
        }


        /// <summary>
        /// Generates the specified maze.
        /// </summary>
        /// <param name="name">The name of maze.</param>
        /// <param name="rows">The rows of maze.</param>
        /// <param name="cols">The cols of maze.</param>
        /// <returns></returns>
        private Maze Generate(string name, int rows, int cols)
        {
            IMazeGenerator g = new DFSMazeGenerator();
            Maze maze = g.Generate(rows, cols);
            maze.Name = name;
            return maze;
        }
    }
}