using MazeLib;
using Newtonsoft.Json.Linq;
using System.Web.Http;
using WebMaze.Models;

namespace WebMaze.Controllers
{
    public class SinglePlayerController : ApiController
    {
        ISinglePlayerModel model = new SinglePlayerModel();

        [HttpGet]
        public JObject GenerateMaze(string name, int rows, int cols)
        {
            Maze maze = model.GenerateMaze(name, rows, cols);
            JObject obj = JObject.Parse(maze.ToJSON());
            return obj;
        }

        [HttpGet]
        public JObject Solve(string mazeName, int typeOfSearch)
        {
            MazeSolution sol =  model.Solve(mazeName, typeOfSearch);
            JObject obj = JObject.Parse(sol.ToJSON());
            return obj;
        }
    }
}
