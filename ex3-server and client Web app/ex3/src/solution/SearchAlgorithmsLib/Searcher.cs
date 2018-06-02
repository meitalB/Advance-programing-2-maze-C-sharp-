using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace SearchAlgorithmsLib
{
    /// <summary>
    /// Abstact class for implement an Sreach algorithms that use a priority queue.
    /// </summary>
    /// <typeparam name="S"> is the type of the states. </typeparam>
    /// <typeparam name="C"> is the type of cost of the state. </typeparam>
    /// <seealso cref="SearchAlgorithmsLib.ISearcher{S, C}" />
    public abstract class Searcher<S, C> : ISearcher<S, C>
    {
        /// <summary>
        /// The open list of the search algorithm - implement by a priority queue.
        /// </summary>
        protected SimplePriorityQueue<State<S, C>, State<S, C>.ICost<C>> openList;

        /// <summary>
        /// Gets the size of the open list.
        /// </summary>
        /// <value>
        /// The size of the open list.
        /// </value>
        public int OpenListSize
        { // it is a read-only property :)
            get { return openList.Count; }
        }

        /// <summary>
        /// The evaluated nodes were evaluated by the algorithm.
        /// </summary>
        private int evaluatedNodes;

        /// <summary>
        /// Initializes a new instance of the <see cref="Searcher{S, C}"/> class.
        /// </summary>
        public Searcher()
        {
            openList = new SimplePriorityQueue<State<S, C>, State<S, C>.ICost<C>>();
            evaluatedNodes = 0;
        }

        /// <summary>
        /// Pushes the open list.
        /// </summary>
        /// <param name="s">The s the state we want to push to the queue.</param>
        protected void pushOpenList(State<S, C> s)
        {
            evaluatedNodes++;
            openList.Enqueue(s, s.cost);
        }

        /// <summary>
        /// Pops the first.
        /// </summary>
        /// <returns> A refernce first state in the queue.</returns>
        protected State<S,C> popFirst()
        {
            return openList.First;
        }

        /// <summary>
        /// Pops the open list.
        /// </summary>
        /// <returns> pop the first state in the guene (and remove it from the queue). </returns>
        protected State<S, C> popOpenList()
        {
            return openList.Dequeue();
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
        /// Updates the place in open list.
        /// </summary>
        /// <param name="s">The s the state we want to update his place.</param>
        /// <param name="c">The c the new cost of the state - accoring to c it will reposition s in te queue.</param>
        protected void UpdatePlaceInOpen(State<S, C> s, State<S,C>.ICost<C> c)
        {
            evaluatedNodes++;
            openList.UpdatePriority(s, c);
        }

        /// <summary>
        /// Searches the specified searchable.
        /// </summary>
        /// <param name="searchable">The searchable is the object we sreach it.</param>
        /// <returns>the solution of the problem.</returns>
        public abstract Solution<S, C> Search(ISearchable<S, C> searchable);
    }
}
