using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BacklogManager.DAL;
using BacklogManager.Models;

namespace BacklogManager.Controllers
{
    public class UserController : ApiController
    {
        private readonly BacklogDbContext _db;

        public UserController()
            : this(new BacklogDbContext())
        {

        }

        public UserController(BacklogDbContext context)
        {
            _db = context;
        }

        public IEnumerable<User> Get()
        {
            return _db.Users.AsNoTracking();
        }


        public User Get(int id)
        {
            return _db.Users.FirstOrDefault(p => p.SocialId == id);
        }

        public void Put(User user)
        {
            if (user != null)
            {
                var existing = Get(user.SocialId);
                if (existing != null)
                {
                    // Update
                    existing.Avatar = user.Avatar;
                    existing.Name = user.Name;
                    existing.Username = user.Username;
                    _db.SaveChanges();
                }
                else
                {
                    // New
                    existing = new User
                    {
                        Avatar = user.Avatar,
                        Name = user.Name,
                        Username = user.Username,
                        SocialId = user.SocialId
                    };
                    _db.Users.Add(existing);
                    _db.SaveChanges();
                }
            }
        }
    }
}