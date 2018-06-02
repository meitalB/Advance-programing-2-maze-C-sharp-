using MazeLib;
using ModelLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MazeGUI.SingleGame
{
    /// <summary>
    /// Class SinglePlayerViewModel.
    /// </summary>
    /// <seealso cref="MazeGUI.NotifyChanged" />
    public class SinglePlayerViewModel : NotifyChanged
    {
        /// <summary>
        /// The model
        /// </summary>
        private ISinglePlayerModel model;
        /// <summary>
        /// The player position
        /// </summary>
        private Position playerPos;
        /// <summary>
        /// You won
        /// </summary>
        private bool youWon;

        /// <summary>
        /// Initializes a new instance of the <see cref="SinglePlayerViewModel"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public SinglePlayerViewModel(ISinglePlayerModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "PlayerPos")
                {
                    PlayerPos = model.PlayerPos;
                }
                else if (e.PropertyName == "YouWon")
                {
                    YouWon = model.YouWon;
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
        /// Gets or sets the maze rows.
        /// </summary>
        /// <value>The maze rows.</value>
        public int MazeRows
        {
            get
            {
                return model.MazeRows;
            }

            set
            {
                NotifyPropertyChanged("MazeRows");
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
        /// Resets this instance.
        /// </summary>
        public void Reset()
        {
            model.Reset();
        }

        /// <summary>
        /// Solves this instance.
        /// </summary>
        public void Solve()
        {
            model.Solve();
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
