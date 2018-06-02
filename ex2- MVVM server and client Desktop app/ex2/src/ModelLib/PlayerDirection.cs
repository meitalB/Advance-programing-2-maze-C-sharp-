using MazeLib;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    /// <summary>
    /// save the direction of the player
    /// </summary>
    public class PlayerDirection
    {
        /// <summary>
        /// Gets or sets the name of the game.
        /// </summary>
        /// <value>
        /// The name of the game.
        /// </value>
        public string GameName
        {
            get; set;
        }
        /// <summary>
        /// Gets or sets the move.
        /// </summary>
        /// <value>
        /// The move.
        /// </value>
        public Direction Move
        {
            get; set;
        }

        /// <summary>
        /// transpose To the json.
        /// </summary>
        /// <returns>string of the direction</returns>
        public string ToJSON()
        {
            JObject obj = new JObject();
            obj["Name"] = GameName;
            obj["Direction"] = Move.ToString();
            return obj.ToString();
        }
        /// <summary>
        /// transpose Froms the json.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>PlayerDirection of the direction</returns>
        public static PlayerDirection FromJSON(string str)
        {
            PlayerDirection pd = new PlayerDirection();
            JObject obj = JObject.Parse(str);
            pd.GameName = (string) obj["Name"];
            pd.Move = (Direction) Enum.Parse(typeof(Direction), ((string) obj["Direction"]));
            return pd;
        }
    }
}
