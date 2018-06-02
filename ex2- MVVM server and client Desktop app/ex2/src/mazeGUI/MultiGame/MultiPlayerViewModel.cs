using MazeLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGUI.MultiGame
{
    /// <summary>
    /// Class MultiPlayerViewModel.
    /// </summary>
    /// <seealso cref="MazeGUI.NotifyChanged" />
    class MultiPlayerViewModel : NotifyChanged
    {

        /// <summary>
        /// The model
        /// </summary>
        private IMultiPlayerModel model;
        /// <summary>
        /// The player position
        /// </summary>
        private Position playerPos;
        /// <summary>
        /// The exit game
        /// </summary>
        private bool exitGame;
        /// <summary>
        /// The lost connection
        /// </summary>
        private bool lostConnection;
        /// <summary>
        /// You won
        /// </summary>
        private bool youWon;
        /// <summary>
        /// The opponent won
        /// </summary>
        private bool opponentWon;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiPlayerViewModel"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public MultiPlayerViewModel(IMultiPlayerModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "PlayerPos")
                {
                    PlayerPos = model.PlayerPos;
                }
                else if (e.PropertyName == "OpponentPos")
                {
                    OpponentPos = model.OpponentPos;
                }
                else if (e.PropertyName == "YouWon")
                {
                    YouWon = model.YouWon;
                }
                else if (e.PropertyName == "OpponentWon")
                {
                    OpponentWon = model.OpponentWon;
                }
                else if (e.PropertyName == "ExitGame")
                {
                    ExitGame = model.ExitGame;
                }
                else if (e.PropertyName == "LostConnection")
                {
                    LostConnection = model.LostConnection;
                }
            };
        }

        /// <summary>
        /// Gets the maze to string.
        /// </summary>
        /// <value>The maze to string.</value>
        public string MazeToString
        {
            get
            {
                string maze = model.MazeToString;
                maze = maze.Replace(Environment.NewLine, "");
                maze = maze.Replace("*", "0");
                maze = maze.Replace("#", "0");
                return maze;
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
                return model.InitialPos;
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
                return model.GoalPos;
            }
        }
        /// <summary>
        /// Gets or sets the player position.
        /// </summary>
        /// <value>The player position.</value>
        public Position PlayerPos
        {
            get
            {
                return playerPos;
            }
            set
            {
                playerPos = value;
                NotifyPropertyChanged("PlayerPos");
            }
        }

        /// <summary>
        /// Gets or sets the opponent position.
        /// </summary>
        /// <value>The opponent position.</value>
        public Position OpponentPos
        {
            get
            {
                return playerPos;
            }
            set
            {
                playerPos = value;
                NotifyPropertyChanged("OpponentPos");
            }
        }

        /// <summary>
        /// Plays the specified move.
        /// </summary>
        /// <param name="move">The move.</param>
        public void Play(Direction move)
        {
            model.MovePlayer(move);
        }


        /// <summary>
        /// Closes this instance.
        /// </summary>
        public void Close()
        {
            model.Close(MazeName);
           
        }

        /// <summary>
        /// Gets the name of the maze.
        /// </summary>
        /// <value>The name of the maze.</value>
        public string MazeName
        {
            get
            {
                return model.MazeName;
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
                return model.MazeRows;
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
                return model.MazeCols;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [exit game].
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
        /// Gets or sets a value indicating whether [lost connection].
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
        /// Gets or sets a value indicating whether [opponent won].
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
        /// Moves the player.
        /// </summary>
        /// <param name="d">The d.</param>
        public void MovePlayer(Direction d)
        {
            model.MovePlayer(d);
        }

    }
}
