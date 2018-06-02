using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib 
{

    /// <summary>
    /// Client
    /// </summary>
    public class Client : AbstractClient 
    {
        /// <summary>
        /// The reading task running
        /// </summary>
        public bool ReadingTaskRunning;

        /// <summary>
        /// The writing task running
        /// </summary>
        public bool WritingTaskRunning;

        private IPEndPoint socketInfo;


        public Client(string IP, int port)
        {
            socketInfo = new IPEndPoint(IPAddress.Parse(IP), port);
            Jobj = new JObject();
            Jobj["close"] = "game-over";
        }

        /// <summary>
        /// Connects this client to the server.
        /// </summary>
        public void Connect()
        {
            tcpClient = new TcpClient();
            Reconnect();
            StartWritingTask();
        }

        private void Reconnect()
        {
            Console.WriteLine("Trying to connect to server");
            tcpClient = new TcpClient();
            try
            {
                tcpClient.Connect(socketInfo);
            }
            catch (SocketException s)
            {
                Console.WriteLine("ERROR: Connection failed.");
                throw s;
            }
            Console.WriteLine("Connection succeeded.");

            InitializeReader();
            InitializeWriter();
            StartReadingTask();
        }

        /// <summary>
        /// Reads result from the server.
        /// </summary>
        /// <returns> the resulting string </returns>
        public string Read()
        {
            // Receive the result from the server.
            string result = Reader.ReadLine();

            if (!string.IsNullOrEmpty(result))
            {
                result = result.Replace("@", System.Environment.NewLine);
                Console.WriteLine(result);
                if (result.Equals("Disconnect"))
                {
                    Disconnect();
                }
            } 
            return result;
        }

        /// <summary>
        /// Writes a command to the server.
        /// </summary>
        public void Write()
        {
            // Send the command to the server.
            string command = Console.ReadLine();

            if (!IsConnected())
            {
                Reconnect();
            }

            Writer.WriteLine(command);
            Writer.Flush();
        }

        /// <summary>
        /// Disposes the writer and reader.
        /// </summary>
        private void Disconnect()
        {
            // Dispose the reader and writer.
            Reader.Dispose();
            Writer.Dispose();

            // Stop the client from constantly reading from server.
            ReadingTaskRunning = false;

            // Close the connection.
            tcpClient.Close();
            Console.WriteLine("Connection has closed.");
        }

        /// <summary>
        /// Starts the reading task.
        /// </summary>
        public void StartReadingTask()
        {
            ReadingTaskRunning = true;

            new Task(() =>
            {
                while (ReadingTaskRunning)
                {
                    Read();
                }
            }).Start();
        }

        /// <summary>
        /// Starts the writing task.
        /// </summary>
        public void StartWritingTask()
        {
            WritingTaskRunning = true;

            new Task(() =>
            {
                while (WritingTaskRunning)
                {
                    Write();
                }
            }).Start();
        }
        
      
    }
}

