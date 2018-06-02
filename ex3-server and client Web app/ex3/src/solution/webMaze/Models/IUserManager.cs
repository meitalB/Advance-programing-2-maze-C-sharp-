using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMaze.Models
{
    interface IUserManager
    {
        IQueryable<User> GetAllUsers();
        User GetUser(string userName);
        int Register(User user);
        int Login(string username, string password);
        int GetDefaultAlgo(int id);
        int GetDefaultCols(int id);
        int GetDefaultRows(int id);
        void UpdateDefaultArgs(string username, int rows, int cols, int defaultAlgo);

    }


}

