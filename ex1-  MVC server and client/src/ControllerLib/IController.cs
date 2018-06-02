using ClientLib;

namespace ControllerLib
{
    /// <summary>
    /// interface the  controller of the mvc model
    /// </summary>
    public interface IController
    {
        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <param name="ch">The ch.</param>
        /// <param name="client">The client.</param>
        /// <returns>string of the command</returns>
        string ExecuteCommand(string args, ClientOfServer client = null);
    }
}
