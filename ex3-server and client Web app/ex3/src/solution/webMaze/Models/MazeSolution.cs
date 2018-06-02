using MazeLib;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMaze.Models
{
    /// <summary>
    /// Maze Solution represent the solution 
    /// </summary>
    public class MazeSolution
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
        /// Gets or sets the solution string.
        /// </summary>
        /// <value>
        /// The solution string.
        /// </value>
        public string SolutionString
        {
            set; get;
        }
        /// <summary>
        /// Gets or sets the solution.
        /// </summary>
        /// <value>
        /// The solution.
        /// </value>
        public List<Position> Solution
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the evaluated nodes.
        /// </summary>
        /// <value>
        /// The evaluated nodes.
        /// </value>
        public int EvaluatedNodes { get; set; }

        /// <summary>
        /// convert maze solotion To the json.
        /// </summary>
        /// <returns></returns>
        public string ToJSON()
        {
            JObject obj = new JObject();
            obj["Name"] = GameName;
            obj["Solution"] = FromListToString();
            obj["NodesEvaluated"] = EvaluatedNodes;
            return obj.ToString();
        }
        /// <summary>
        /// Froms the json.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        public static MazeSolution FromJSON(string str)
        {
            MazeSolution ms = new MazeSolution();
            JObject obj = JObject.Parse(str);
            ms.GameName = (string)obj["Name"];
            ms.SolutionString = (string)obj["Solution"];
            ms.EvaluatedNodes = (int)obj["NodesEvaluated"];
            return ms;
        }

        /// <summary>
        /// Froms the list to string.
        /// </summary>
        /// <returns>System.String.</returns>
        private string FromListToString()
        {
            string solution = "";
            for (int i = Solution.Count - 1; i > 0 ; i--)
            {
                solution += ComparePosition(Solution[i], Solution[i-1]).ToString();
            }
            return solution;
        }

        /// <summary>
        /// Compares the position.
        /// </summary>
        /// <param name="p1">The p1.</param>
        /// <param name="p2">The p2.</param>
        /// <returns>System.Char.</returns>
        private char ComparePosition(Position p1, Position p2)
        {
            if (p2.Row < p1.Row) { return 'U'; } // up
            if (p2.Row > p1.Row) { return 'D'; } // down
            if (p2.Col < p1.Col) { return 'L'; }//left
            return 'R'; //  if (p2.Col > p1.Col)  - right
        }
        
    }

}

