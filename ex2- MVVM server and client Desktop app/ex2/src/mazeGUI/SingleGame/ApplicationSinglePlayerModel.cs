using MazeLib;
using System;
using System.Net;
using System.Threading.Tasks;
using ModelLib;
using System.Threading;

namespace MazeGUI.SingleGame
{
    /// <summary>
    /// Class ApplicationSinglePlayerModel.
    /// </summary>
    /// <seealso cref="MazeGUI.Model" />
    /// <seealso cref="MazeGUI.SingleGame.ISinglePlayerModel" />
    public class ApplicationSinglePlayerModel : Model, ISinglePlayerModel
    {
        /// <summary>
        /// The default search algorithm
        /// </summary>
        private int defaultSearchAlgorithm;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationSinglePlayerModel"/> class.
        /// </summary>
        /// <param name="mazeName">Name of the maze.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="cols">The cols.</param>
        public ApplicationSinglePlayerModel(string mazeName, int rows, int cols)
        {
            youWon = false;
            string ip = Properties.Settings.Default.ServerIP;
            int port = Properties.Settings.Default.ServerPort;
            socketInfo = new IPEndPoint(IPAddress.Parse(ip), port);
            defaultSearchAlgorithm = Properties.Settings.Default.SearchAlgorithm;
            GenerateMaze(mazeName, rows, cols);
        }

        /// <summary>
        /// Generates the maze.
        /// </summary>
        /// <param name="mazeName">Name of the maze.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="cols">The cols.</param>
        private void GenerateMaze(string mazeName, int rows, int cols)
        {
            Connect();
            Writer.Flush();
            Writer.WriteLine("generate {0} {1} {2}", mazeName, rows, cols);
            Writer.Flush();
            string answer = Reader.ReadLine();
            Disconnect();
            answer = answer.Replace("@", Environment.NewLine);
            Maze = Maze.FromJSON(answer);
            PlayerPos = Maze.InitialPos;
            CreateMazeCells(MazeToString);
        }


        /// <summary>
        /// Solves this instance.
        /// </summary>
        public void Solve()
        {
            Connect();
            Writer.WriteLine("solve {0} {1}", maze.Name, defaultSearchAlgorithm);
            Writer.Flush();
            string answer = Reader.ReadLine();
            answer = answer.Replace("@", Environment.NewLine);
            Disconnect();
            MazeSolution ms = MazeSolution.FromJSON(answer);
            RunSolveTask(ms.SolutionString);
        }

        /// <summary>
        /// Runs the solve task.
        /// </summary>
        /// <param name="solutionString">The solution string.</param>
        private void RunSolveTask(string solutionString)
        {
            Reset();
            new Task(() =>
            {
                foreach (char direction in solutionString)
                {
                    switch (direction)
                    {
                        case 'U':
                            PlayerPos = new Position(PlayerPos.Row - 1, PlayerPos.Col);
                            break;

                        case 'D':
                            PlayerPos = new Position(PlayerPos.Row + 1, PlayerPos.Col);
                            break;

                        case 'R':
                            PlayerPos = new Position(PlayerPos.Row, PlayerPos.Col + 1);
                            break;

                        case 'L':
                            PlayerPos = new Position(PlayerPos.Row, PlayerPos.Col - 1);
                            break;

                        default:
                            return;
                    }
                    Thread.Sleep(120);
                }
            }).Start();
        }

        /// <summary>
        /// Resets this instance.
        /// </summary>
        public void Reset()
        {
            PlayerPos = Maze.InitialPos;
        }

        /// <summary>
        /// Moves the player.
        /// </summary>
        /// <param name="d">The d.</param>
        public void MovePlayer(Direction d)
        {
            try
            {
                PlayerPos = CheckMovement(PlayerPos,d);
            }
            catch (Exception) { }
        }
    }
}
