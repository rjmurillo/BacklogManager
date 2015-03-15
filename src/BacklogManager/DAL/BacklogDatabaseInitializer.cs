using System.Collections.Generic;
using System.Data.Entity;
using BacklogManager.Models;

namespace BacklogManager.DAL
{
    public class BacklogDatabaseInitializer : DropCreateDatabaseAlways<BacklogDbContext>
    {
        protected override void Seed(BacklogDbContext context)
        {
            var items = new[]
            {
                new BacklogItem {ID=1, Owner = "Fake", Title = "First Backlog Item"},
                new BacklogItem {ID=2, Owner = "Fake", Title = "Second Backlog Item"},
                new BacklogItem {ID=3, Owner = "Fake", Title = "Third Backlog Item"},
                new BacklogItem {ID=4, Owner = "Fake", Title = "Fourth Backlog Item"},
                new BacklogItem {ID=5, Owner = "Fake", Title = "Fifth Backlog Item"}
            };

            context.BacklogItems.AddRange(items);

            base.Seed(context);
        }
    }
}