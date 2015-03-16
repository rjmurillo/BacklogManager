using System;
using System.Data.Entity.Migrations;
using System.Linq;
using BacklogManager.DAL;
using BacklogManager.Models;

namespace BacklogManager.Migrations
{


    internal sealed class Configuration : DbMigrationsConfiguration<BacklogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BacklogDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. 

            if (!context.Projects.Any())
            {

                var projects = new[]
                {
                    new Project {Color = "#FFA62F", Name = "Le Cantaloop"},
                    new Project {Color = "#9B59B6", Name = "IE Agents"},
                    new Project {Color = "#F39C12", Name = "Bug Funnel"},
                    new Project {Color = "#B390D4", Name = "Project Management"},
                    new Project {Color = "#F4D03F", Name = "IC productivity"}
                };

                context.Projects.AddOrUpdate(p => new {p.Color}, projects);
            }

            if (!context.Users.Any())
            {
                var users = new[]
                {
                    new User
                    {
                        Username = "oodarichard",
                        Name = "Richard Murillo",
                        Avatar = "https://pbs.twimg.com/profile_images/573785723758854144/9f2yuFnf_200x200.jpeg",
                        SocialId = 580668794
                    },
                    new User
                    {
                        Username = "smnkhn",
                        Name = "Salman Khan",
                        Avatar = "https://pbs.twimg.com/profile_images/571335588016447488/J1d4tDS__200x200.jpeg"
                    },
                    new User
                    {
                        Username = "CollWilliams",
                        Name = "Colleen Williams",
                        Avatar = "https://pbs.twimg.com/profile_images/439858746936659968/5pVxClm9_200x200.png"
                    },
                    new User
                    {
                        Username = "mgradwohl",
                        Name = "Matt Gradwohl",
                        Avatar = "https://pbs.twimg.com/profile_images/1865267615/Xbox_Ring_200x200.jpg"
                    },
                    new User
                    {
                        Username = "thejohnjansen",
                        Name = "John Jansen",
                        Avatar = "https://pbs.twimg.com/profile_images/1110399708/bdayParty_200x200.jpg"
                    }
                };

                context.Users.AddOrUpdate(u => new {u.Username}, users);
            }

            if (!context.BacklogItems.Any())
            {
                var items = new[]
                {
                    new BacklogItem
                    {
                        Owner = context.Users.Local[0],
                        Project = context.Projects.Local[0],
                        Upvotes = 15,
                        Discipline = "software engineer",
                        Action = "adopt an effective process",
                        Goal = "I can be more productive"
                    },
                    new BacklogItem
                    {
                        Owner = context.Users.Local[1],
                        Project = context.Projects.Local[1],
                        Upvotes = 3,
                        Discipline = "manager",
                        Action = "auto create tasks from deliverables for my ICs",
                        Goal = "I have more time to code"
                    },
                    new BacklogItem
                    {
                        Owner = context.Users.Local[2],
                        Project = context.Projects.Local[2],
                        Upvotes = 4,
                        Discipline = "program manager",
                        Action = "see a daily report on bugs in my area path",
                        Goal = "I can calculate my triage rate"
                    },
                    new BacklogItem
                    {
                        Owner = context.Users.Local[3],
                        Project = context.Projects.Local[3],
                        Upvotes = 8,
                        Discipline = "developer",
                        Action = "see a breakdown of my time spent on tasks",
                        Goal = "I can identify which tasks takes me longer"
                    },
                    new BacklogItem
                    {
                        Owner = context.Users.Local[4],
                        Project = context.Projects.Local[4],
                        Upvotes = 0,
                        Discipline = "developer",
                        Action = "count how many reduction bugs I can delegate",
                        Goal = "I spend more time building features"
                    }
                };


                var rank = 1;
                foreach (var item in items.OrderByDescending(k => k.Upvotes))
                {
                    item.CreatedDate = DateTimeOffset.UtcNow;
                    item.GlobalRank = rank;
                    rank++;

                }

                context.BacklogItems.AddOrUpdate(i => new {i.Discipline, i.Action, i.Goal}, items);
            }
        }
    }
}
