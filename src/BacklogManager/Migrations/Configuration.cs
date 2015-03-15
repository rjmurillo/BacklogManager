using BacklogManager.Models;

namespace BacklogManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BacklogManager.DAL.BacklogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BacklogManager.DAL.BacklogDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //

            var users = new[]
            {
                new User(){ID = 1, Username = "oodarichard", Name = "Richard Murillo", Avatar = "https://pbs.twimg.com/profile_images/573785723758854144/9f2yuFnf_200x200.jpeg"},
                new User{ID=2, Username = "smnkhn", Name = "Salman Khan", Avatar = "https://pbs.twimg.com/profile_images/571335588016447488/J1d4tDS__200x200.jpeg"},
                new User{ID=3, Username = "CollWilliams", Name = "Colleen Williams", Avatar = "https://pbs.twimg.com/profile_images/439858746936659968/5pVxClm9_200x200.png"},
                new User{ID=4, Username = "mgradwohl", Name = "Matt Gradwohl", Avatar = "https://pbs.twimg.com/profile_images/1865267615/Xbox_Ring_200x200.jpg"},
                new User{ID=5, Username = "thejohnjansen", Name = "John Jansen", Avatar = "https://pbs.twimg.com/profile_images/1110399708/bdayParty_200x200.jpg"}
            };

            context.Users.AddRange(users);

            var items = new[]
            {
                new BacklogItem {ID=1, Owner = users[0], Upvotes = 15, Discipline = "software engineer", Action = "adopt an effective process", Goal = "I can be more productive"},
                new BacklogItem {ID=2, Owner = users[1], Upvotes = 3, Discipline = "manager", Action = "auto create tasks from deliverables for my ICs", Goal = "I have more time to code"},
                new BacklogItem {ID=3, Owner = users[2], Upvotes = 4, Discipline = "program manager", Action = "see a daily report on bugs in my area path", Goal = "I can calculate my triage rate"},
                new BacklogItem {ID=4, Owner = users[3], Upvotes = 8, Discipline = "developer", Action = "see a breakdown of my time spent on tasks", Goal = "I can identify which tasks takes me longer"},
                new BacklogItem {ID=5, Owner = users[4], Upvotes = 0, Discipline = "developer", Action = "count how many reduction bugs I can delegate", Goal = "I spend more time building features"},
                new BacklogItem {ID=6, Owner = users[0], Upvotes = 15, Discipline = "software engineer", Action = "adopt an effective process", Goal = "I can be more productive"},
                new BacklogItem {ID=7, Owner = users[1], Upvotes = 3, Discipline = "manager", Action = "auto create tasks from deliverables for my ICs", Goal = "I have more time to code"},
                new BacklogItem {ID=8, Owner = users[2], Upvotes = 4, Discipline = "program manager", Action = "see a daily report on bugs in my area path", Goal = "I can calculate my triage rate"},
                new BacklogItem {ID=9, Owner = users[3], Upvotes = 8, Discipline = "developer", Action = "see a breakdown of my time spent on tasks", Goal = "I can identify which tasks takes me longer"},
                new BacklogItem {ID=10, Owner = users[4], Upvotes = 0, Discipline = "developer", Action = "count how many reduction bugs I can delegate", Goal = "I spend more time building features"},
                new BacklogItem {ID=11, Owner = users[0], Upvotes = 15, Discipline = "software engineer", Action = "adopt an effective process", Goal = "I can be more productive"},
                new BacklogItem {ID=12, Owner = users[1], Upvotes = 3, Discipline = "manager", Action = "auto create tasks from deliverables for my ICs", Goal = "I have more time to code"},
                new BacklogItem {ID=13, Owner = users[2], Upvotes = 4, Discipline = "program manager", Action = "see a daily report on bugs in my area path", Goal = "I can calculate my triage rate"},
                new BacklogItem {ID=14, Owner = users[3], Upvotes = 8, Discipline = "developer", Action = "see a breakdown of my time spent on tasks", Goal = "I can identify which tasks takes me longer"},
                new BacklogItem {ID=15, Owner = users[4],  Upvotes = 0, Discipline = "developer", Action = "count how many reduction bugs I can delegate", Goal = "I spend more time building features"},
                new BacklogItem {ID=16, Owner = users[0], Upvotes = 15, Discipline = "software engineer", Action = "adopt an effective process", Goal = "I can be more productive"},
                new BacklogItem {ID=17, Owner = users[1], Upvotes = 3, Discipline = "manager", Action = "auto create tasks from deliverables for my ICs", Goal = "I have more time to code"},
                new BacklogItem {ID=18, Owner = users[2], Upvotes = 4, Discipline = "program manager", Action = "see a daily report on bugs in my area path", Goal = "I can calculate my triage rate"},
                new BacklogItem {ID=19, Owner = users[3], Upvotes = 8, Discipline = "developer", Action = "see a breakdown of my time spent on tasks", Goal = "I can identify which tasks takes me longer"},
                new BacklogItem {ID=20, Owner = users[4], Upvotes = 0, Discipline = "developer", Action = "count how many reduction bugs I can delegate", Goal = "I spend more time building features"}
            };

            context.BacklogItems.AddRange(items);
        }
    }
}
