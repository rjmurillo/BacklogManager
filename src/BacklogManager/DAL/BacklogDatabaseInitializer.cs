using System;
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
                new BacklogItem {ID=1, Owner = "oodarichard", Name = "Richard Murillo",  Title = "First Backlog Item", Avatar = "https://pbs.twimg.com/profile_images/573785723758854144/9f2yuFnf_200x200.jpeg", Upvotes = 15, Discipline = "software engineer", Action = "adopt an effective process", Goal = "I can be more productive"},
                new BacklogItem {ID=2, Owner = "smnkhn", Name = "Salman Khan", Title = "Second Backlog Item", Avatar = "https://pbs.twimg.com/profile_images/571335588016447488/J1d4tDS__200x200.jpeg", Upvotes = 3, Discipline = "manager", Action = "auto create tasks from deliverables for my ICs", Goal = "I have more time to code"},
                new BacklogItem {ID=3, Owner = "CollWilliams", Name = "Colleen Williams", Title = "Third Backlog Item", Avatar = "https://pbs.twimg.com/profile_images/439858746936659968/5pVxClm9_200x200.png", Upvotes = 4, Discipline = "program manager", Action = "see a daily report on bugs in my area path", Goal = "I can calculate my triage rate"},
                new BacklogItem {ID=4, Owner = "mgradwohl", Name = "Matt Gradwohl", Title = "Fourth Backlog Item", Avatar = "https://pbs.twimg.com/profile_images/1865267615/Xbox_Ring_200x200.jpg", Upvotes = 8, Discipline = "developer", Action = "see a breakdown of my time spent on tasks", Goal = "I can identify which tasks takes me longer"},
                new BacklogItem {ID=5, Owner = "thejohnjansen", Name = "John Jansen", Title = "Fifth Backlog Item", Avatar = "https://pbs.twimg.com/profile_images/1110399708/bdayParty_200x200.jpg", Upvotes = 0, Discipline = "developer", Action = "count how many reduction bugs I can delegate", Goal = "I spend more time building features"},
                new BacklogItem {ID=6, Owner = "oodarichard", Name = "Richard Murillo",  Title = "First Backlog Item", Avatar = "https://pbs.twimg.com/profile_images/573785723758854144/9f2yuFnf_200x200.jpeg", Upvotes = 15, Discipline = "software engineer", Action = "adopt an effective process", Goal = "I can be more productive"},
                new BacklogItem {ID=7, Owner = "smnkhn", Name = "Salman Khan", Title = "Second Backlog Item", Avatar = "https://pbs.twimg.com/profile_images/571335588016447488/J1d4tDS__200x200.jpeg", Upvotes = 3, Discipline = "manager", Action = "auto create tasks from deliverables for my ICs", Goal = "I have more time to code"},
                new BacklogItem {ID=8, Owner = "CollWilliams", Name = "Colleen Williams", Title = "Third Backlog Item", Avatar = "https://pbs.twimg.com/profile_images/439858746936659968/5pVxClm9_200x200.png", Upvotes = 4, Discipline = "program manager", Action = "see a daily report on bugs in my area path", Goal = "I can calculate my triage rate"},
                new BacklogItem {ID=9, Owner = "mgradwohl", Name = "Matt Gradwohl", Title = "Fourth Backlog Item", Avatar = "https://pbs.twimg.com/profile_images/1865267615/Xbox_Ring_200x200.jpg", Upvotes = 8, Discipline = "developer", Action = "see a breakdown of my time spent on tasks", Goal = "I can identify which tasks takes me longer"},
                new BacklogItem {ID=10, Owner = "thejohnjansen", Name = "John Jansen", Title = "Fifth Backlog Item", Avatar = "https://pbs.twimg.com/profile_images/1110399708/bdayParty_200x200.jpg", Upvotes = 0, Discipline = "developer", Action = "count how many reduction bugs I can delegate", Goal = "I spend more time building features"},
                new BacklogItem {ID=11, Owner = "oodarichard", Name = "Richard Murillo",  Title = "First Backlog Item", Avatar = "https://pbs.twimg.com/profile_images/573785723758854144/9f2yuFnf_200x200.jpeg", Upvotes = 15, Discipline = "software engineer", Action = "adopt an effective process", Goal = "I can be more productive"},
                new BacklogItem {ID=12, Owner = "smnkhn", Name = "Salman Khan", Title = "Second Backlog Item", Avatar = "https://pbs.twimg.com/profile_images/571335588016447488/J1d4tDS__200x200.jpeg", Upvotes = 3, Discipline = "manager", Action = "auto create tasks from deliverables for my ICs", Goal = "I have more time to code"},
                new BacklogItem {ID=13, Owner = "CollWilliams", Name = "Colleen Williams", Title = "Third Backlog Item", Avatar = "https://pbs.twimg.com/profile_images/439858746936659968/5pVxClm9_200x200.png", Upvotes = 4, Discipline = "program manager", Action = "see a daily report on bugs in my area path", Goal = "I can calculate my triage rate"},
                new BacklogItem {ID=14, Owner = "mgradwohl", Name = "Matt Gradwohl", Title = "Fourth Backlog Item", Avatar = "https://pbs.twimg.com/profile_images/1865267615/Xbox_Ring_200x200.jpg", Upvotes = 8, Discipline = "developer", Action = "see a breakdown of my time spent on tasks", Goal = "I can identify which tasks takes me longer"},
                new BacklogItem {ID=15, Owner = "thejohnjansen", Name = "John Jansen", Title = "Fifth Backlog Item", Avatar = "https://pbs.twimg.com/profile_images/1110399708/bdayParty_200x200.jpg", Upvotes = 0, Discipline = "developer", Action = "count how many reduction bugs I can delegate", Goal = "I spend more time building features"},
                new BacklogItem {ID=16, Owner = "oodarichard", Name = "Richard Murillo",  Title = "First Backlog Item", Avatar = "https://pbs.twimg.com/profile_images/573785723758854144/9f2yuFnf_200x200.jpeg", Upvotes = 15, Discipline = "software engineer", Action = "adopt an effective process", Goal = "I can be more productive"},
                new BacklogItem {ID=17, Owner = "smnkhn", Name = "Salman Khan", Title = "Second Backlog Item", Avatar = "https://pbs.twimg.com/profile_images/571335588016447488/J1d4tDS__200x200.jpeg", Upvotes = 3, Discipline = "manager", Action = "auto create tasks from deliverables for my ICs", Goal = "I have more time to code"},
                new BacklogItem {ID=18, Owner = "CollWilliams", Name = "Colleen Williams", Title = "Third Backlog Item", Avatar = "https://pbs.twimg.com/profile_images/439858746936659968/5pVxClm9_200x200.png", Upvotes = 4, Discipline = "program manager", Action = "see a daily report on bugs in my area path", Goal = "I can calculate my triage rate"},
                new BacklogItem {ID=19, Owner = "mgradwohl", Name = "Matt Gradwohl", Title = "Fourth Backlog Item", Avatar = "https://pbs.twimg.com/profile_images/1865267615/Xbox_Ring_200x200.jpg", Upvotes = 8, Discipline = "developer", Action = "see a breakdown of my time spent on tasks", Goal = "I can identify which tasks takes me longer"},
                new BacklogItem {ID=20, Owner = "thejohnjansen", Name = "John Jansen", Title = "Fifth Backlog Item", Avatar = "https://pbs.twimg.com/profile_images/1110399708/bdayParty_200x200.jpg", Upvotes = 0, Discipline = "developer", Action = "count how many reduction bugs I can delegate", Goal = "I spend more time building features"}
            };

            context.BacklogItems.AddRange(items);

            base.Seed(context);
        }
    }
}