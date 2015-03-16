namespace BacklogManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SocialId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "SocialId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "SocialId");
        }
    }
}
