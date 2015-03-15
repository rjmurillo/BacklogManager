﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using BacklogManager.DAL;
using BacklogManager.Models;

namespace BacklogManager.Controllers
{
    public class BacklogController : ApiController
    {
        private readonly BacklogDbContext _db;

        public BacklogController()
            : this(new BacklogDbContext())
        {
        }

        public BacklogController(BacklogDbContext context)
        {
            _db = context;
        }

        // GET: api/backlog
        public IEnumerable<BacklogItem> Get()
        {
            return _db.BacklogItems.AsNoTracking();
        }

        // GET: api/backlog/5
        public BacklogItem Get(int id)
        {
            return _db.BacklogItems.AsNoTracking().FirstOrDefault(a => a.ID == id);
        }

        // POST: api/backlog
        public void Post(BacklogItem backlogItem)
        {
            _db.BacklogItems.Add(backlogItem);
            _db.SaveChanges();
        }

        // PUT: api/backlog
        public void Put(BacklogItem backlogItem)
        {
            if (backlogItem != null)
            {
                var current = Get(backlogItem.ID);
                current.Title = backlogItem.Title;
                _db.SaveChanges();
            }
        }

        // DELETE: api/backlog/5
        public void Delete(int id)
        {
            var backlogItem = Get(id);
            if (backlogItem != null)
            {
                _db.BacklogItems.Remove(backlogItem);
                _db.SaveChanges();
            }
        }
    }
}