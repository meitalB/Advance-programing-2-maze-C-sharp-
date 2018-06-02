using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ControllerLib
{

    /// <summary>
    /// define the multi command
    /// </summary>
    /// <seealso cref="ControllerLib.Command" />
    abstract class MultiCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MultiCommand"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public MultiCommand(IModel model) : base(model)
        {
        }
    }
}
