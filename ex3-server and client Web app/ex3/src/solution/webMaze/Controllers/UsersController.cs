using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using WebMaze.Models;

namespace WebMaze.Controllers
{
    public class UsersController : ApiController
    {
        private WebMazeContext db = new WebMazeContext();

        // GET: api/Users
        public IQueryable<User> GetUsers()
        {
            return db.Users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(string username)
        {
            User user = db.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            //encrypting the password.
            SHA1 s = SHA1.Create();
            byte[] buffer = Encoding.ASCII.GetBytes(user.Password);
            byte[] hashCode = s.ComputeHash(buffer);
            user.Password = Convert.ToBase64String(hashCode);

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { username = user.Username }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(string username)
        {
            return db.Users.Count(e => e.Username == username) > 0;
        }

        // POST: api/Users
        [HttpGet]
        public IHttpActionResult Login(string username, string password)
        {
            User user = db.Users.FirstOrDefault(u => u.Username == username);


            if (user != null)
            {
                //encrypting the password.
                SHA1 s = SHA1.Create();
                byte[] buffer = Encoding.ASCII.GetBytes(password);
                byte[] hashCode = s.ComputeHash(buffer);
                string encryptedPassword = Convert.ToBase64String(hashCode);
                if (user.Password != encryptedPassword)
                {
                    return BadRequest("username or password incorrect.");
                }
                return Ok(username);
            }
            return NotFound();
        }

        // POST: api/Users
        [HttpGet]
        public IHttpActionResult Win(string username, int type)
        {
            User user = db.Users.FirstOrDefault(u => u.Username == username);


            if (user != null)
            {
                if (type == 1)
                {
                    user.Wins++;
                } else if (type == 0)
                {
                    user.Losses++;
                }
                db.SaveChanges();
                return Ok(username);
            }
            return NotFound();
        }
    }
}