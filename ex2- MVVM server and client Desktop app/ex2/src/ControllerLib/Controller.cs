using ClientLib;
using ModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace ControllerLib
{
    /// <summary>
    /// controllef part of mvc
    /// </summary>
    /// <seealso cref="ControllerLib.IController" />
    public class Controller : IController
    {
        /// <summary>
        /// The commands dictionary
        /// </summary>
        private Dictionary<string, ICommand> commands;
        /// <summary>
        /// The model an interface
        /// </summary>
        private IModel model;
        /// <summary>
        /// Sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public IModel Model
        {
            set { model = value; }
        }

        /// <summary>
        /// Initializes a new instance of the Controller <see cref="Controller"/> class.
        /// </summary>
        /// <param name="imodel">The imodel.</param>
        public Controller(IModel imodel)
        {
            Model = imodel;
            commands = new Dictionary<string, ICommand>
            {
                { "generate", new GenerateMazeCommand(model) },
                { "solve", new SolveCommand(model) },
                { "start", new StartCommand(model) },
                { "list", new ListCommand(model) },
                { "play", new  PlayCommand(model) },
                { "join", new  JoinCommand(model) },
                { "close", new CloseCommand(model) }
            };
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="commandLine">The command line.</param>
        /// <param name="ch">The ClientHandler.</param>
        /// <param name="client">The client.</param>
        /// <returns>the string of the command </returns>
        public string ExecuteCommand(string commandLine, ClientOfServer client = null)
        {
            string[] arr = commandLine.Split(' ');
            string commandKey = arr[0];
            if (!commands.ContainsKey(commandKey))
                return "Command not found";
            string[] args = arr.Skip(1).ToArray();
            ICommand command = commands[commandKey];
            //if  (command is SingleCommand || command is CloseCommand)
            //{
            //    ch.StopConnetion();
            //}
            return command.Execute(args, client);
        }
    }
}