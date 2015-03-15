namespace BacklogManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingrankfieldstoPBI : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BacklogItem", "TeamRank", c => c.Int(nullable: false));
            AddColumn("dbo.BacklogItem", "GlobalRank", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BacklogItem", "GlobalRank");
            DropColumn("dbo.BacklogItem", "TeamRank");
        }
    }
}
