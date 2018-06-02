using System.Collections.Generic;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// An class that represent the solution of the sreachers algorithms. 
    /// </summary>
    /// <typeparam name="S"> is the type of the states. </typeparam>
    /// <typeparam name="C"> is the type of cost of the state. </typeparam>
    public class Solution<S, C>
    {
        /// <summary>
        /// The evaluated nodes were evaluated by the algorithm.
        /// </summary>
        private int evaluatedNodes;
        /// <summary>
        /// The solution - list of the states which represent the solution.
        /// </summary>
        private List<State<S, C>> solution;

        /// <summary>
        /// Gets the solution.
        /// </summary>
        /// <returns>list of the states which represent the solution. </returns>
        public List<State<S, C>> GetSolution()
        {
            return solution;
        }

        /// <summary>
        /// Gets the evaluated nodes.
        /// </summary>
        /// <returns>The evaluated nodes were evaluated by the algorithm.</returns>
        public int GetEvaluatedNodes()
        {
            return evaluatedNodes;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Solution{S, C}"/> class.
        /// </summary>
        /// <param name="solution">The solution - list of the states which represent the solution.</param>
        /// <param name="evaluatedNodes">The evaluated nodes were evaluated by the algorithm.</param>
        public Solution(List<State<S, C>> solution, int evaluatedNodes)
        {
            this.solution = solution;
            this.evaluatedNodes = evaluatedNodes;
        }
    }
}