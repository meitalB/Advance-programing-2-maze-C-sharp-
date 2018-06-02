using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace ControllerLib
{
    /// <summary>
    /// define Single Commands
    /// </summary>
    /// <seealso cref="ControllerLib.Command" />
    abstract class SingleCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the Single Command <see cref="SingleCommand"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public SingleCommand(IModel model) : base(model)
        {
        }
    }
}
