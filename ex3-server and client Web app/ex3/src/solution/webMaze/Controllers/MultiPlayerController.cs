using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebMaze.Models;

namespace WebMaze.Controllers
{
    public class MultiPlayerController : ApiController
    {
        IMultiPlayerModel model = new MultiPlayerModel();


        [HttpGet]
        public JObject Start(string name, int rows, int cols)
        {
            //Maze maze = model.GenerateMaze(name, rows, cols);
            //JObject obj = JObject.Parse(maze.ToJSON());
            //return obj;
            throw new Exception();

        }
    }
}
