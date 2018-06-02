using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebMaze.Models
{
    public class UsersModel : IUserManager
    {
        private WebMazeContext db = new WebMazeContext();


        public void AddUser(User p)
        {
            db.Users.Add(p);
            db.SaveChanges();
        }

        public IQueryable<User> GetAllUsers()
        {
            return db.Users;
        }

        public int GetDefaultAlgo(int id)
        {
            throw new NotImplementedException();
        }

        public int GetDefaultCols(int id)
        {
            throw new NotImplementedException();
        }

        public int GetDefaultRows(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string userName)
        {
            return db.Users.FirstOrDefault(u => u.Username == userName);
        }

        //public void UpdateUser(User p)
        //{
        //    User prod = db.Users.Where(x => x.Id == p.Id).FirstOrDefault();
        //    prod.Username = p.Username;
        //    prod.Password = p.Password;
        //    prod.Email = p.Email;
        //}

        public int Login(string username, string password)
        {
            User user = db.Users.FirstOrDefault(u => u.Username == username);

            if (user != null)
            {
                if (user.Password == password)
                {
                    return 1;
                }
            }
            return -1;
        }


        public int Register(User user)
        {
            User user2 = db.Users.FirstOrDefault(u => u.Username == user.Username);

            if (user != null)
            {
                return -1;
            }
            db.Users.Add(user);
            db.SaveChanges();

            return 1;
        }

        public void UpdateDefaultArgs(string username, int rows, int cols, int defaultAlgo)
        {
            throw new NotImplementedException();
        }

        //    public int GetDefaultAlgo(int id)
        //    {
        //        User p = db.Users.Where(x => x.Id == id).FirstOrDefault();
        //        return p.DefaultAlgo;
        //    }
        //    public int GetDefaultCols(int id)
        //    {
        //        User p = db.Users.Where(x => x.Id == id).FirstOrDefault();
        //        return p.DefaultCols;
        //    }
        //    public int GetDefaultRows(int id)
        //    {
        //        User p = db.Users.Where(x => x.Id == id).FirstOrDefault();
        //        return p.DefaultRows;
        //    }
        //    public void UpdateDefaultArgs(string username,int rows,int cols,int defaultAlgo)
        //    {
        //        User prod = db.Users.Where(x => x.Username == username).FirstOrDefault();
        //        prod.DefaultRows = rows;
        //        prod.DefaultCols = cols;
        //        prod.DefaultAlgo = defaultAlgo;
        //    }
    }
}
