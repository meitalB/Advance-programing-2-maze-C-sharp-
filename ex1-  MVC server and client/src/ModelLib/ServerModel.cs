using MazeGeneratorLib;
using MazeLib;
using System;
using System.Collections.Generic;
using SearchAlgorithmsLib;
using System.Net.Sockets;
using ClientLib;


namespace ModelLib
{
    /// <summary>
    /// the model part of the server
    /// </summary>
    public class ServerModel : IModel
    {
        /// <summary>
        /// The mazes Dictionary -all the mazes
        /// </summary>
        private Dictionary<string, Maze> mazes;
        /// <summary>
        /// The Dictionary of multi player waiting
        /// </summary>
        private Dictionary<string, MultiPlayerInfo> multiPlayerWaiting;
        /// <summary>
        /// The Dictionary multi player online
        /// </summary>
        private Dictionary<string, MultiPlayerInfo> multiPlayerOnline;
        /// <summary>
        /// The mazes solutions Dictionary
        /// </summary>
        private Dictionary<string, MazeSolution> mazesSolutions;

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerModel"/> class.
        /// </summary>
        public ServerModel()
        {
            mazes = new Dictionary<string, Maze>();
            multiPlayerWaiting = new Dictionary<string, MultiPlayerInfo>();
            multiPlayerOnline = new Dictionary<string, MultiPlayerInfo>();
            mazesSolutions = new Dictionary<string, MazeSolution>();
        }


        /// <summary>
        /// Closes the specified server model.
        /// </summary>
        /// <param name="name">The name of maze.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Close(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generates the maze.
        /// </summary>
        /// <param name="name">The name of maze.</param>
        /// <param name="rows">The rows of maze.</param>
        /// <param name="cols">The cols of maze.</param>
        /// <returns>new maze as requserted</returns>
        public Maze GenerateMaze(string name, int rows, int cols)
        {
            Maze maze = Generate(name, rows, cols);
            mazes.Add(name, maze);
            return maze;
        }

        /// <summary>
        /// Joins the specified name.
        /// </summary>
        /// <param name="name">The name of maze.</param>
        /// <param name="guest">The guest client.</param>
        /// <returns the maze></returns>
        /// <exception cref="System.Exception">This maze does not exist - " + name</exception>
        public Maze Join(string name, ClientOfServer guest)
        {
            if (!multiPlayerWaiting.ContainsKey(name))
            {
                throw new Exception("This maze does not exist - " + name);
            }
            MultiPlayerInfo mp = multiPlayerWaiting[name];
            mp.Guest = guest;
            multiPlayerOnline[name] = mp;
            multiPlayerWaiting.Remove(name);
            return mp.Maze;
        }

        /// <summary>
        /// Lists this instance.
        /// </summary>
        /// <returns>list of all the online maze now client can join</returns>
        public List<string> List()
        {
            Dictionary<string, MultiPlayerInfo>.KeyCollection namesCollaction = multiPlayerWaiting.Keys;
            string[] temp = new string[namesCollaction.Count];
            namesCollaction.CopyTo(temp, 0);
            return new List<string>(temp);
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
            if (mazesSolutions.ContainsKey(name))
            {
                return mazesSolutions[name];
            }

            if (mazes.ContainsKey(name))
            {
                Maze maze = mazes[name];
                MazeSolution s = Solve(maze, typeOfSolve);
                mazesSolutions.Add(name, s);
                return s;
            }

            //if (multiPlayerWaiting.ContainsKey(name))
            //{
            //    Maze maze = multiPlayerWaiting[name];
            //    MazeSolution s = Solve(maze, typeOfSolve);
            //    mazesSolutions.Add(name, s);
            //    return s;
            //}

            throw new Exception("This maze does not exist - " + name);
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

        /// <summary>
        /// Starts the specified of maze.
        /// </summary>
        /// <param name="name">The name of maze.</param>
        /// <param name="rows">The rows of maze.</param>
        /// <param name="cols">The cols of maze.</param>
        /// <param name="host">The host of maze.</param>
        public void Start(string name, int rows, int cols, ClientOfServer host)
        {
            Maze maze = Generate(name, rows, cols);
            MultiPlayerInfo mp = new MultiPlayerInfo()
            {
                Host = host,
                Maze = maze
            };
            multiPlayerWaiting.Add(name, mp);
        }

        /// <summary>
        /// Solves the specified maze.
        /// </summary>
        /// <param name="maze">The maze.</param>
        /// <param name="type">The type.</param>
        /// <returns>the Maze Solution</returns>
        /// <exception cref="System.Exception">This search type does not exist - " + type</exception>
        private MazeSolution Solve(Maze maze, int type)
        {
            ObjectAdapter adapter = new ObjectAdapter(maze);

            BFS<Position, int> bfs = new BFS<Position, int>();
            DFS<Position, int> dfs = new DFS<Position, int>();
            switch (type)
            {
                case 0:
                    return ConvertSolution(bfs.Search(adapter), maze.Name);
                case 1:
                    return ConvertSolution(dfs.Search(adapter), maze.Name);
                default:
                    throw new Exception("This search type does not exist - " + type);
            }
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
            return ms;

        }

        /// <summary>
        /// Determines whether the specified name is pair.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        ///   <c>true</c> if the specified name is pair; otherwise, <c>false</c>.
        /// </returns>
        public bool IsPair(string name)
        {
            return multiPlayerOnline.ContainsKey(name);
        }

        /// <summary>
        /// Gets the maze.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>the current maze</returns>
        /// <exception cref="System.Exception">This maze does not exist - " + name</exception>
        public Maze GetMaze(string name)
        {
            if (multiPlayerWaiting.ContainsKey(name))
            {
                return multiPlayerWaiting[name].Maze;
            }

            if (mazes.ContainsKey(name))
            {
                return mazes[name];
            }

            ///
            if (multiPlayerOnline.ContainsKey(name))
            {
                return multiPlayerOnline[name].Maze;
            }
            throw new Exception("This maze does not exist - " + name);
            
        }

        /// <summary>
        /// Plays the specified move.
        /// </summary>
        /// <param name="move">The move.</param>
        /// <param name="player">The player.</param>
        /// <returns>map of TcpClient, PlayerDirection </returns>
        public Tuple<ClientOfServer, PlayerDirection> Play(string move, ClientOfServer player)
        {
            MultiPlayerInfo mp = FindMPInfo(player);
            ClientOfServer otherPlayer = mp.GetTheOtherPlayer(player);
            PlayerDirection pd = new PlayerDirection()
            {
                GameName = mp.Maze.Name,
                Move = move
            };
            return new Tuple<ClientOfServer, PlayerDirection>(otherPlayer, pd);
        }

        public ClientOfServer Close(string name, ClientOfServer player)
        {
            MultiPlayerInfo mp = multiPlayerOnline[name];
            multiPlayerOnline.Remove(name);
            return mp.GetTheOtherPlayer(player);
        }

        /// <summary>
        /// Finds the Multi Player information.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <returns>the current Multi Player </returns>
        /// <exception cref="System.Exception">This player does not exist.</exception>
        private MultiPlayerInfo FindMPInfo(ClientOfServer player)
        {
            foreach (MultiPlayerInfo mp in multiPlayerOnline.Values)
            {
                if (mp.ContainPlayer(player))
                {
                    return mp;
                }
            }
            throw new Exception("This player does not exist.");
        }
    }
}
