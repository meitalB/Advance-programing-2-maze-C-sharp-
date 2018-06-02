using ClientLib;
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
    /// abstract class of the controler
    /// </summary>
    /// <seealso cref="ControllerLib.ICommand" />
    abstract class Command : ICommand
    {
        /// <summary>
        /// The model of the mvc
        /// </summary>
        protected IModel model;
        /// <summary>
        /// Initializes a new instance of the <see cref="Command"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public Command(IModel model)
        {
            this.model = model;
        }

        /// <summary>
        /// Executes the specified arguments abstract method.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="ch">The ch.</param>
        /// <param name="client">The client.</param>
        /// <returns>
        /// string of the command
        /// </returns>
        public abstract string Execute(string[] args, ClientOfServer client = null);
    }
}
