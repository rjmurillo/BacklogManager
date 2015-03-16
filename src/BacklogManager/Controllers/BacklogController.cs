using System;
using System.Collections.Generic;
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
            return _db.BacklogItems.FirstOrDefault(a => a.ID == id);
        }

        // POST: api/backlog
        public void Post(BacklogItem backlogItem)
        {
            backlogItem.GlobalRank = _db.BacklogItems.Max(s => s.GlobalRank) + 1;
            backlogItem.CreatedDate = DateTimeOffset.UtcNow;
            _db.BacklogItems.Add(backlogItem);
            _db.SaveChanges();
        }

        // PUT: api/backlog
        public void Put(BacklogItem backlogItem)
        {
            if (backlogItem != null)
            {
                var current = Get(backlogItem.ID);
                if (current != null)
                {
                    current.Action = backlogItem.Action;
                    current.Discipline = backlogItem.Discipline;
                    current.Goal = backlogItem.Goal;
                    current.Upvotes = backlogItem.Upvotes;

                    if (current.GlobalRank != backlogItem.GlobalRank)
                    {
                        var arr = _db.BacklogItems.ToArray();
                        var temp = arr[0];

                        for (int write = 0; write < arr.Length; write++)
                        {
                            for (int sort = 0; sort < arr.Length - 1; sort++)
                            {
                                if (arr[sort].GlobalRank > arr[sort + 1].GlobalRank)
                                {
                                    temp = arr[sort + 1];
                                    arr[sort + 1] = arr[sort];
                                    arr[sort] = temp;
                                }
                            }
                        }

                        for (int i = 0; i < arr.Length; i++)
                        {
                            arr[i].GlobalRank = i;
                        }
                    }



                    _db.SaveChanges();
                }
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
