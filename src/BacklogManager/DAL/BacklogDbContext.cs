using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using BacklogManager.Models;

namespace BacklogManager.DAL
{
    public class BacklogDbContext : DbContext
    {
        public BacklogDbContext()
            : base("BacklogDbContext")
        {
        }
        public DbSet<BacklogItem> BacklogItems { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Otherwise everything is NVARCHAR(MAX)
            modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(4000));
        }
    }

    public static class BacklogDbContextExtensions
    {
        public static IQueryable<BacklogItem> CompleteBacklogItems(this BacklogDbContext context)
        {
            return context.BacklogItems
                .Include(p => p.Owner)
                .Include(p => p.Project);
        }
    }
}