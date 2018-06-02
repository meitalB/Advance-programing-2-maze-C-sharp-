using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// Interface of objects that can search information in an ISreachable objects.
    /// </summary>
    /// <typeparam name="S"> is the type of the states. </typeparam>
    /// <typeparam name="C"> is the type of cost of the state. </typeparam>
    public interface ISearcher<S, C>
    {
        /// <summary>
        /// Searches the specified searchable.
        /// </summary>
        /// <param name="searchable">The searchable is the object we sreach it.</param>
        /// <returns>the solution of the problem.</returns>
        Solution<S, C> Search(ISearchable<S, C> searchable);

        /// <summary>
        /// Gets how many nodes were evaluated by the algorithm.
        /// </summary>
        /// <returns> integer number of the number of nodes evaluated. </returns>
        int getNumberOfNodesEvaluated();
    }
}
