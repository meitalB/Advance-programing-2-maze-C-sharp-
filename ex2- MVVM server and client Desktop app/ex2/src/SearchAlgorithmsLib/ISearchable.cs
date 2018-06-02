using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// Interface of a objects that we can sreach information of them.
    /// such as mazes, graphs, maps ext. 
    /// </summary>
    /// <typeparam name="S"> is the type of the states. </typeparam>
    /// <typeparam name="C"> is the type of cost of the state. </typeparam>
    public interface ISearchable<S, C>
    {
        /// <summary>
        /// Gets the initial state.
        /// </summary>
        /// <returns>the initial state of the sreach problem.</returns>
        State<S, C> GetInitialState();
        /// <summary>
        /// Gets the state of the goal.
        /// </summary>
        /// <returns>the goal state of the sreach problem.</returns>
        State<S, C> GetGoalState();
        /// <summary>
        /// Gets all possible states.
        /// </summary>
        /// <param name="s">The s parameter is the state which we want to get his possible states for continue the sreach. </param>
        /// <returns>list of the possible states - the successors of s.</returns>
        List<State<S, C>> GetAllPossibleStates(State<S, C> s);
        /// <summary>
        /// Betters the direction if possible.
        /// </summary>
        /// <param name="s1">The s1 is the state which we want to improve his direction.</param>
        /// <param name="s2">The s2 is the state which we check if the direction to s2 through s1 is better than us current direction.</param>
        /// <returns> boolean if there is a better direction of not. </returns>
        bool BetterDirection(State<S, C> s1, State<S, C> s2);
    }
}
