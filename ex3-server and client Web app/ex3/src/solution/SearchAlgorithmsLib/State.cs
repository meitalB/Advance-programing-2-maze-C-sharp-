using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
namespace SearchAlgorithmsLib
{
    /// <summary>
    /// This class represent a state of search algorithm.
    /// </summary>
    /// <typeparam name="S"> is the type of the states. </typeparam>
    /// <typeparam name="C"> is the type of cost of the state. </typeparam>
    public class State<S, C>
    {
        /// <summary>
        /// The cost to reach this StateValue;
        /// </summary>
        public ICost<C> cost;

        /// <summary>
        /// Inner class that responsible to create an instance of states.
        /// This class enables you to reduce the overhead of creating each state from scratch.
        /// When an state is activated, it is pulled from the pool. 
        /// When the state is deactivated, it is placed back into the pool to await the next request.
        /// </summary>
        public static class StatePool
        {
            /// <summary>
            /// The pool of the state - inplement by an dictionary , the keys are hashCode of the state.
            /// </summary>
            private static Dictionary<int, State<S, C>> pool = new Dictionary<int, State<S, C>>();

            /// <summary>
            /// Gets the state.
            /// </summary>
            /// <param name="state">The type of the value of the wanted state.</param>
            /// <returns> the instance of the state. </returns>
            public static  State<S, C> GetState(S  state)
            {
                if (pool.ContainsKey(state.ToString().GetHashCode()))
                {
                    return pool[state.ToString().GetHashCode()];
                } else
                {
                    State<S, C> s = new State<S, C>(state);
                    pool[state.ToString().GetHashCode()] = s;
                    return pool[state.ToString().GetHashCode()];
               
                }
            }
        }

        /// <summary>
        /// The state value
        /// </summary>
        private S stateValue;

        /// <summary>
        /// Gets or sets the state value.
        /// </summary>
        /// <value>
        /// The state value.
        /// </value>
        public S StateValue
        {
            get { return stateValue; }
            set { stateValue = value; }
        }

        /// <summary>
        /// The came from - the parent state of this state.
        /// </summary>
        private State<S, C> cameFrom;
        /// <summary>
        /// Gets or sets the came from.
        /// </summary>
        /// <value>
        /// The came from.
        /// </value>
        public State<S, C> CameFrom
        {
            set { cameFrom = value; }
            get { return cameFrom; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="State{S, C}"/> class.
        /// </summary>
        /// <param name="state">The value of the state.</param>
        private State(S state)
        {
            StateValue = state;
            CameFrom = null;
        }


        /// <summary>
        /// Equalses the specified s.
        /// </summary>
        /// <param name="s">The s is the compared state.</param>
        /// <returns> boolean if s is equal to this state. </returns>
        public bool Equals(State<S, C> s)
        {
            return StateValue.Equals(s.StateValue);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as State<S, C>);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return StateValue.ToString().GetHashCode();
        }

        /// <summary>
        /// Interface for the cost of the state.
        /// </summary>
        /// <typeparam name="V"> the type of the cost</typeparam>
        public interface ICost<V> : IComparable<ICost<V>>
        {
            /// <summary>
            /// Gets or sets the value.
            /// </summary>
            /// <value>
            /// The value of the cost.
            /// </value>
            V Value { get; set; }

            /// <summary>
            /// Adds a cost to the current cost.
            /// </summary>
            /// <param name="c">The c is the cost we want to add.</param>
            void AddCost(ICost<V> c);
        }
    }
}
