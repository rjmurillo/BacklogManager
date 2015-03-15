using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BacklogManager.Models;

namespace BacklogManager.DAL
{
    public class BacklogDbContext : DbContext
    {
        public BacklogDbContext()
            : base("BacklogDbContext")
        { }
        public DbSet<BacklogItem> BacklogItems { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}