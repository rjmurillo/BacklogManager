using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BacklogManager.DAL;
using BacklogManager.Models;

namespace BacklogManager.Controllers
{
    public class ProjectController : ApiController
    {
        private readonly BacklogDbContext _db;

        public ProjectController()
            :this(new BacklogDbContext())
        {
        }

        private ProjectController(BacklogDbContext db)
        {
            _db = db;
            _db.Database.Log = Console.Write; 

        }

        // GET: api/project
        public IEnumerable<Project> Get()
        {
            return _db.Projects.AsNoTracking();
        }

        // GET: api/project/5
        public Project Get(int id)
        {
            return _db.Projects.FirstOrDefault(a => a.ID == id);
        }

        // POST: api/project
        public void Post(Project project)
        {
            _db.Projects.Add(project);
            _db.SaveChanges();
        }

        // PUT: api/project
        public void Put(Project project)
        {
            if (project != null)
            {
                var current = Get(project.ID);
                if (current != null)
                {
                    current.Color = project.Color;
                    current.Name = project.Name;
                    _db.SaveChanges();
                }
                else
                {
                    Post(project);
                }
            }
        }
    }
}