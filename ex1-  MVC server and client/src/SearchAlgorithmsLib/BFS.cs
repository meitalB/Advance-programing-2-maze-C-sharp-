using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SearchAlgorithmsLib
{
    /// <summary>
    /// Implemention of Best First Sreach algorithm.
    /// </summary>
    /// <typeparam name="S"> is the type of the states. </typeparam>
    /// <typeparam name="C"> is the type of the cost of each state. </typeparam>
    /// <seealso cref="SearchAlgorithmsLib.Searcher{S, C}" />
    public class BFS<S, C> : Searcher<S, C> 
    {

        /// <summary>
        /// Searches the specified searchable.
        /// </summary>
        /// <param name="searchable">The searchable is the object we sreach it.</param>
        /// <returns>the solution of the problem.</returns>
        public override Solution<S, C> Search(ISearchable<S, C> searchable)
        {
            State<S, C> start = searchable.GetInitialState();
            start.CameFrom = null;
            pushOpenList(start); // inherited from Searcher
            HashSet<State<S, C>> closed = new HashSet<State<S, C>>();
            while (OpenListSize > 0)
            {
                State<S, C> n = popOpenList(); // inherited from Searcher, removes the best StateValue
                closed.Add(n);
                if (n == searchable.GetGoalState())
                    return BackTrace(n); // private method, back traces through the parents
                                        // calling the delegated method, returns a list of states with n as a parent
                List<State<S, C>> succerssors = searchable.GetAllPossibleStates(n);
                foreach (State<S, C> s in succerssors)
                {
                    if (!closed.Contains(s) && !openList.Contains(s))
                    {
                        s.CameFrom = n;
                        pushOpenList(s);
                    }
                    else if (openList.Contains(s) && searchable.BetterDirection(n, s))
                    {
                            UpdatePlaceInOpen(s, s.cost);
                    }
                }
            }
            return null;
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
