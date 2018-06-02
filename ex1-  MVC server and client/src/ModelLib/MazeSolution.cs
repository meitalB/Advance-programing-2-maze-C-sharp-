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

        private string FromListToString()
        {
            string solution = "";
            for (int i = 1; i < Solution.Count; i++)
            {
                solution += ComparePosition(Solution[i - 1], Solution[i]).ToString();
            }
            return solution;
        }

        private int ComparePosition(Position p1, Position p2)
        {
            if (p2.Row < p1.Row) { return 0; }
            if (p2.Row > p1.Row) { return 1; }
            if (p2.Col < p1.Col) { return 2; }
            return 3; //  if (p2.Col > p1.Col) 
        }

    }
}

