using MazeLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MazeGUI
{
    /// <summary>
    /// Class Model.
    /// </summary>
    /// <seealso cref="MazeGUI.NotifyChanged" />
    public abstract class Model : NotifyChanged
    {
        /// <summary>
        /// The maze cells
        /// </summary>
        protected List<List<int>> mazeCells;
        /// <summary>
        /// The maze
        /// </summary>
        protected Maze maze;
        /// <summary>
        /// The player position
        /// </summary>
        protected Position playerPos;
        /// <summary>
        /// The socket information
        /// </summary>
        protected IPEndPoint socketInfo;
        /// <summary>
        /// The TCP client
        /// </summary>
        protected TcpClient tcpClient;
        /// <summary>
        /// The reader
        /// </summary>
        protected StreamReader Reader;
        /// <summary>
        /// The writer
        /// </summary>
        protected StreamWriter Writer;
        /// <summary>
        /// You won
        /// </summary>
        protected bool youWon;

        /// <summary>
        /// Creates the maze cells.
        /// </summary>
        /// <param name="mazeToString">The maze to string.</param>
        protected void CreateMazeCells(string mazeToString)
        {
            string[] rowsStinrgs = mazeToString.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            int rowIndex = 0;
            mazeCells = new List<List<int>>(MazeRows);
            foreach (String row in rowsStinrgs)
            {
                mazeCells.Add(new List<int>(MazeCols));

                for (int i = 0; i < MazeCols; i++)
                {
                    if (row[i] == '1')
                        mazeCells[rowIndex].Insert(i, 1);
                    else
                        mazeCells[rowIndex].Insert(i, 0);
                }
                rowIndex++;
            }
        }

        /// <summary>
        /// Checks the movement.
        /// </summary>
        /// <param name="p">The p.</param>
        /// <param name="d">The d.</param>
        /// <returns>Position.</returns>
        /// <exception cref="System.Exception">
        /// Unvalid movement.
        /// or
        /// Unvalid movement.
        /// </exception>
        public Position CheckMovement(Position p,Direction d)
        { 
            int x = p.Col;
            int y = p.Row;
            Position temp;
            switch (d)
            {
                case Direction.Up:
                    temp = new Position(y - 1, x);
                    break;

                case Direction.Down:
                    temp = new Position(y + 1, x);
                    break;

                case Direction.Right:
                    temp = new Position(y, x + 1);
                    break;

                case Direction.Left:
                    temp = new Position(y, x - 1);
                    break;

                default:
                    throw new Exception("Unvalid movement.");

            }
            if (IsValidPos(temp))
            {
                return temp;
            }
            else { throw new Exception("Unvalid movement."); }
        }

        /// <summary>
        /// Determines whether [is valid position] [the specified position].
        /// </summary>
        /// <param name="pos">The position.</param>
        /// <returns><c>true</c> if [is valid position] [the specified position]; otherwise, <c>false</c>.</returns>
        protected bool IsValidPos(Position pos)
        {
            if (pos.Col < MazeCols && pos.Row < MazeRows && pos.Col >= 0 && pos.Row >= 0 && mazeCells[pos.Row][pos.Col] == 0)
                return true;
            return false;
        }

        /// <summary>
        /// Gets or sets the maze.
        /// </summary>
        /// <value>The maze.</value>
        public Maze Maze
        {
            get { return maze; }
            set
            {
                maze = value;
                NotifyPropertyChanged("Maze");
            }
        }

        /// <summary>
        /// Gets or sets the player position.
        /// </summary>
        /// <value>The player position.</value>
        public Position PlayerPos
        {
            get { return playerPos; }
            set
            {
                playerPos = value;
                NotifyPropertyChanged("PlayerPos");
                if (ReachedGoalPos(playerPos))
                {
                    YouWon = true;
                } else if (YouWon == true)
                {
                    YouWon = false;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [you won].
        /// </summary>
        /// <value><c>true</c> if [you won]; otherwise, <c>false</c>.</value>
        public bool YouWon
        {
            get { return youWon; }
            set
            {
                youWon = value;
                NotifyPropertyChanged("YouWon");
            }
        }
        /// <summary>
        /// Gets the name of the maze.
        /// </summary>
        /// <value>The name of the maze.</value>
        public string MazeName
        {
            get
            {
                return maze.Name;
            }
        }
        /// <summary>
        /// Gets the maze rows.
        /// </summary>
        /// <value>The maze rows.</value>
        public int MazeRows
        {
            get
            {
                return maze.Rows;
            }
        }
        /// <summary>
        /// Gets the maze cols.
        /// </summary>
        /// <value>The maze cols.</value>
        public int MazeCols
        {
            get
            {
                return maze.Cols;
            }
        }

        /// <summary>
        /// Gets the maze to string.
        /// </summary>
        /// <value>The maze to string.</value>
        public string MazeToString
        {
            get
            {
                return maze.ToString();
            }
        }

        /// <summary>
        /// Gets the initial position.
        /// </summary>
        /// <value>The initial position.</value>
        public Position InitialPos
        {
            get
            {
                return maze.InitialPos;
            }
        }

        /// <summary>
        /// Gets the goal position.
        /// </summary>
        /// <value>The goal position.</value>
        public Position GoalPos
        {
            get
            {
                return maze.GoalPos;
            }
        }
        /// <summary>
        /// Reacheds the goal position.
        /// </summary>
        /// <param name="pos">The position.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        protected bool ReachedGoalPos(Position pos)
        {
            if (pos.Col == GoalPos.Col && pos.Row == GoalPos.Row)
                return true;
            else return false;
        }
        /// <summary>
        /// Connects this instance.
        /// </summary>
        protected void Connect()
        {
            Console.WriteLine("Trying to connect to server");
            tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(socketInfo);
            }
            catch (SocketException s)
            {
                Console.WriteLine("ERROR: Connection failed.");
                throw s;
            }
            Console.WriteLine("Connection succeeded.");

            InitializeReader();
            InitializeWriter();
        }

        /// <summary>
        /// Initializes the reader.
        /// </summary>
        protected void InitializeReader()
        {
            Reader = new StreamReader(tcpClient.GetStream());
        }

        /// <summary>
        /// Initializes the writer.
        /// </summary>
        protected void InitializeWriter()
        {
            Writer = new StreamWriter(tcpClient.GetStream());
        }

        /// <summary>
        /// Disposes the writer and reader.
        /// </summary>
        protected void Disconnect()
        {
            // Dispose the reader and writer.
            Reader.Dispose();
            Writer.Dispose();

            // Close the connection.
            tcpClient.Close();
            Console.WriteLine("Connection has closed.");
        }

    }
}
