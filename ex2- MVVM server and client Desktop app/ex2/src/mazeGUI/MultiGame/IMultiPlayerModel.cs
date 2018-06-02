using MazeLib;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading.Tasks;

namespace MazeGUI.MultiGame
{
    /// <summary>
    /// Interface IMultiPlayerModel
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public interface IMultiPlayerModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Starts the specified maze name.
        /// </summary>
        /// <param name="mazeName">Name of the maze.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="cols">The cols.</param>
        void Start(string mazeName, int rows, int cols);
        /// <summary>
        /// Joins the specified maze name.
        /// </summary>
        /// <param name="mazeName">Name of the maze.</param>
        void Join(string mazeName);
        /// <summary>
        /// Closes the specified maze name.
        /// </summary>
        /// <param name="mazeName">Name of the maze.</param>
        void Close(string mazeName);
        /// <summary>
        /// Moves the player.
        /// </summary>
        /// <param name="d">The d.</param>
        void MovePlayer(Direction d);
        /// <summary>
        /// Gets the player position.
        /// </summary>
        /// <value>The player position.</value>
        Position PlayerPos { get; }
        /// <summary>
        /// Gets the opponent position.
        /// </summary>
        /// <value>The opponent position.</value>
        Position OpponentPos { get; }
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
        /// Gets the games list.
        /// </summary>
        /// <value>The games list.</value>
        List<string> GamesList { get; }
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
        /// Gets a value indicating whether [exit game].
        /// </summary>
        /// <value><c>true</c> if [exit game]; otherwise, <c>false</c>.</value>
        bool ExitGame { get; }
        /// <summary>
        /// Gets a value indicating whether [lost connection].
        /// </summary>
        /// <value><c>true</c> if [lost connection]; otherwise, <c>false</c>.</value>
        bool LostConnection { get; }
        /// <summary>
        /// Gets a value indicating whether [opponent won].
        /// </summary>
        /// <value><c>true</c> if [opponent won]; otherwise, <c>false</c>.</value>
        bool OpponentWon { get; }
        /// <summary>
        /// Gets a value indicating whether [you won].
        /// </summary>
        /// <value><c>true</c> if [you won]; otherwise, <c>false</c>.</value>
        bool YouWon { get; }
    }
}
