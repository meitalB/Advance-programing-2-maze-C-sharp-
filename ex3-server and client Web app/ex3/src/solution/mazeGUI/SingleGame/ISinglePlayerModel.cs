using ModelLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeLib;
using System.Drawing;

namespace MazeGUI.SingleGame
{
    /// <summary>
    /// Interface ISinglePlayerModel
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public interface ISinglePlayerModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets the maze to string.
        /// </summary>
        /// <value>The maze to string.</value>
        string MazeToString { get; }
        /// <summary>
        /// Gets the name of the maze.
        /// </summary>
        /// <value>The name of the maze.</value>
        string MazeName { get; }
        /// <summary>
        /// Gets the maze rows.
        /// </summary>
        /// <value>The maze rows.</value>
        int MazeRows { get; }
        /// <summary>
        /// Gets the maze cols.
        /// </summary>
        /// <value>The maze cols.</value>
        int MazeCols { get; }
        /// <summary>
        /// Gets the player position.
        /// </summary>
        /// <value>The player position.</value>
        Position PlayerPos { get; }
        /// <summary>
        /// Gets the initial position.
        /// </summary>
        /// <value>The initial position.</value>
        Position InitialPos { get; }
        /// <summary>
        /// Gets the goal position.
        /// </summary>
        /// <value>The goal position.</value>
        Position GoalPos { get; }
        /// <summary>
        /// Gets a value indicating whether [you won].
        /// </summary>
        /// <value><c>true</c> if [you won]; otherwise, <c>false</c>.</value>
        bool YouWon { get; }
        /// <summary>
        /// Solves this instance.
        /// </summary>
        void Solve();
        /// <summary>
        /// Moves the player.
        /// </summary>
        /// <param name="d">The d.</param>
        void MovePlayer(Direction d);
        /// <summary>
        /// Resets this instance.
        /// </summary>
        void Reset();
    }
}
