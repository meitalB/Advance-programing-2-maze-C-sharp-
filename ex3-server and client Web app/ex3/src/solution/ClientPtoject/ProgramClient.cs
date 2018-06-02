using ClientLib;
using System.Configuration;

namespace ClientProject
{
    class ProgramClient
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args)
        {
            string ip = ConfigurationManager.AppSettings["IP"];
            string port = ConfigurationManager.AppSettings["Port"];
            Client client = new Client(ip, int.Parse(port));
            client.Connect();
            // Wait for the writing and reading tasks to finish.
            while (client.ReadingTaskRunning || client.WritingTaskRunning) { }
            client.Close();
        }
    }
}
