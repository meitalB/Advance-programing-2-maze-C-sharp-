using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using System.Net.Sockets;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using ModelLib;
using System.Threading;
using System.Drawing;
using System.Windows.Threading;
using System.Windows;

namespace MazeGUI.MultiGame
{
    /// <summary>
    /// Class ApplicationMultiPlayerModel.
    /// </summary>
    /// <seealso cref="MazeGUI.Model" />
    /// <seealso cref="MazeGUI.MultiGame.IMultiPlayerModel" />
    public class ApplicationMultiPlayerModel : Model, IMultiPlayerModel
    {

        /// <summary>
        /// The opponent position
        /// </summary>
        private Position opponentPos;
        /// <summary>
        /// The stop reading
        /// </summary>
        private bool stopReading;
        /// <summary>
        /// The stop executing commands
        /// </summary>
        private bool stopExecutingCommands;
        /// <summary>
        /// The lost connection
        /// </summary>
        private bool lostConnection;
        /// <summary>
        /// The opponent won
        /// </summary>
        private bool opponentWon;
        /// <summary>
        /// The exit game
        /// </summary>
        private bool exitGame;
        /// <summary>
        /// The server commands
        /// </summary>
        private Queue<string> serverCommands;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationMultiPlayerModel"/> class.
        /// </summary>
        public ApplicationMultiPlayerModel()
        {
            string ip = Properties.Settings.Default.ServerIP;
            int port = Properties.Settings.Default.ServerPort;
            socketInfo = new IPEndPoint(IPAddress.Parse(ip), port);
            serverCommands = new Queue<string>();
            lostConnection = false;
            youWon = false;
            opponentWon = false;
            exitGame = false;
        }

        /// <summary>
        /// Gets the opponent position.
        /// </summary>
        /// <value>The opponent position.</value>
        public Position OpponentPos
        {
            get { return opponentPos; }
            set
            {
                opponentPos = value;
                NotifyPropertyChanged("OpponentPos");
                if (ReachedGoalPos(opponentPos))
                {
                    OpponentWon = true;
                }
                else if (OpponentWon == true)
                {
                    OpponentWon = false;
                }
            }
        }


        /// <summary>
        /// Gets a value indicating whether [lost connection].
        /// </summary>
        /// <value><c>true</c> if [lost connection]; otherwise, <c>false</c>.</value>
        public bool LostConnection
        {
            get { return lostConnection; }
            set
            {
                lostConnection = value;
                NotifyPropertyChanged("LostConnection");
            }
        }

        /// <summary>
        /// Gets a value indicating whether [exit game].
        /// </summary>
        /// <value><c>true</c> if [exit game]; otherwise, <c>false</c>.</value>
        public bool ExitGame
        {
            get { return exitGame; }
            set
            {
                exitGame = value;
                NotifyPropertyChanged("ExitGame");
            }
        }

        /// <summary>
        /// Gets a value indicating whether [opponent won].
        /// </summary>
        /// <value><c>true</c> if [opponent won]; otherwise, <c>false</c>.</value>
        public bool OpponentWon
        {
            get { return opponentWon; }
            set
            {
                opponentWon = value;
                NotifyPropertyChanged("OpponentWon");
            }
        }

        /// <summary>
        /// Starts the specified maze name.
        /// </summary>
        /// <param name="mazeName">Name of the maze.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="cols">The cols.</param>
        public void Start(string mazeName, int rows, int cols)
        {
            Connect();
            Writer.WriteLine("start {0} {1} {2}", mazeName, rows, cols);
            Writer.Flush();
            GetMaze();
        }

        /// <summary>
        /// Joins the specified maze name.
        /// </summary>
        /// <param name="mazeName">Name of the maze.</param>
        public void Join(string mazeName)
        {
            Connect();
            Writer.WriteLine("join {0}", mazeName);
            Writer.Flush();
            GetMaze();
        }

        /// <summary>
        /// Gets the maze.
        /// </summary>
        private void GetMaze()
        {
            string answer = Reader.ReadLine();
            answer = answer.Replace("@", Environment.NewLine);
            Maze = Maze.FromJSON(answer);
            PlayerPos = Maze.InitialPos;
            OpponentPos = Maze.InitialPos;
            CreateMazeCells(MazeToString);
            CreateTasks();
        }


        /// <summary>
        /// Creates the tasks.
        /// </summary>
        private void CreateTasks()
        {   // create a reading task  
            new Task(() =>
            {
                stopReading = false;
                string answer;
                while (!stopReading)
                {
                    try
                    {
                        answer = Reader.ReadLine();
                        if (!string.IsNullOrEmpty(answer))
                        {
                            answer = answer.Replace("@", Environment.NewLine);
                            serverCommands.Enqueue(answer);
                        }
                    }
                    catch (IOException)
                    {
                        stopReading = true;
                        stopExecutingCommands = true;
                        LostConnection = true;
                    }
                }
            }).Start();

            // create executing commands task.
            new Task(() =>
            {
                stopExecutingCommands = false;
                while (!stopExecutingCommands)
                {
                    while (!stopExecutingCommands && serverCommands.Count > 0)
                    {
                        string command = serverCommands.Dequeue();
                        try
                        {
                            PlayerDirection pd = PlayerDirection.FromJSON(command);
                            UpDateOpponentPos(pd.Move);
                            Thread.Sleep(500);
                        }
                        catch (Exception)
                        {
                            if (command == "Disconnect")
                            {
                                stopReading = true;
                                stopExecutingCommands = true;
                                ExitGame = true;
                            }
                        }
                    }
                }
            }).Start();
        }
        /// <summary>
        /// Ups the date opponent position.
        /// </summary>
        /// <param name="move">The move.</param>
        private void UpDateOpponentPos(Direction move)
        {
            try
            {
                OpponentPos = CheckMovement(OpponentPos, move);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Moves the player.
        /// </summary>
        /// <param name="move">The move.</param>
        public void MovePlayer(Direction move)
        {
            try
            {
                PlayerPos = CheckMovement(PlayerPos, move);
                UpdateServer(move);
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Updates the server.
        /// </summary>
        /// <param name="d">The d.</param>
        private void UpdateServer(Direction d)
        {
            string move = "";
            switch (d)
            {
                case Direction.Left:
                    move = "Left";
                    break;
                case Direction.Right:
                    move = "Right";
                    break;
                case Direction.Up:
                    move = "Up";
                    break;
                case Direction.Down:
                    move = "Down";
                    break;

            }
            Writer.WriteLine("play {0}", move);
            Writer.Flush();
        }

        /// <summary>
        /// Gets the games list.
        /// </summary>
        /// <value>The games list.</value>
        public List<string> GamesList
        {
            get
            {
                Connect();
                Writer.WriteLine("list");
                Writer.Flush();
                string answer = Reader.ReadLine();
                answer = answer.Replace("@", Environment.NewLine);
                Disconnect();
                return JsonConvert.DeserializeObject<List<string>>(answer);
            }
        }

        /// <summary>
        /// Closes the specified maze name.
        /// </summary>
        /// <param name="mazeName">Name of the maze.</param>
        public void Close(string mazeName)
        {
            stopReading = true;
            stopExecutingCommands = true;
            Writer.WriteLine("close {0}", mazeName);
            Writer.Flush();
            //if (!(Reader.ReadLine() == "Disconnect"))
            //{
            //    Console.WriteLine("Fail to disconnect server.");
            //}
        }
    }
}
