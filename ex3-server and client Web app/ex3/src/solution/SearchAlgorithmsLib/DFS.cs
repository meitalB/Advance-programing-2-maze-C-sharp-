using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// Implemention of Depth First Sreach algorithm.
    /// </summary>
    /// <typeparam name="S"> is the type of the states. </typeparam>
    /// <typeparam name="C"> is the type of the cost of each state. </typeparam>
    /// <seealso cref="SearchAlgorithmsLib.Searcher{S, C}" />
    public class DFS<S, C> : ISearcher<S, C>
    {
        /// <summary>
        /// The evaluated nodes were evaluated by the algorithm.
        /// </summary>
        private int evaluatedNodes;

        /// <summary>
        /// Initializes a new instance of the <see cref="DFS{S, C}"/> class.
        /// </summary>
        public DFS()
        {
            evaluatedNodes = 0;
        }

        /// <summary>
        /// Gets how many nodes were evaluated by the algorithm.
        /// </summary>
        /// <returns>
        /// integer number of the number of nodes evaluated.
        /// </returns>
        public int getNumberOfNodesEvaluated()
        {
            return evaluatedNodes;
        }

        /// <summary>
        /// Searches the specified searchable.
        /// </summary>
        /// <param name="searchable">The searchable is the object we sreach it.</param>
        /// <returns>the solution of the problem.</returns>
        public Solution<S, C> Search(ISearchable<S, C> searchable)
        {
            State<S, C> s;
            //For DFS use stack
            Stack<State<S, C>> stack = new Stack<State<S, C>>();
            List<State<S, C>> visited = new List<State<S, C>>();
            evaluatedNodes++;
            stack.Push(searchable.GetInitialState());

            while (stack.Count != 0)
            {
                s = stack.Pop();

                if (s.Equals(searchable.GetGoalState()))
                    return BackTrace(s);

                foreach (State<S, C> i in searchable.GetAllPossibleStates(s))
                {
                    evaluatedNodes++;
                    if (i.CameFrom == null && !i.Equals(searchable.GetInitialState()))
                    {
                        i.CameFrom = s;
                        stack.Push(i);
                    }
                }
            }
            throw new Exception("Goal state didn't found!");
        }


        /// <summary>
        /// Backs the trace.
        /// </summary>
        /// <param name="n">The n paramter is the last state of the solution .</param>
        /// <returns>Returns the solution of this sreach problem. </returns>
        private Solution<S, C> BackTrace(State<S, C> n)
        {
            List<State<S, C>> solution = new List<State<S, C>>();
            while (n != null)
            {
                solution.Add(n);
                n = n.CameFrom;
            }
            return new Solution<S, C>(solution, getNumberOfNodesEvaluated());
        }
    }
}
