namespace BacklogManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BacklogItem",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OwnerId = c.Int(nullable: false),
                        Upvotes = c.Int(nullable: false),
                        Discipline = c.String(),
                        Action = c.String(),
                        Goal = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.OwnerId, cascadeDelete: true)
                .Index(t => t.OwnerId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Name = c.String(),
                        Avatar = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BacklogItem", "OwnerId", "dbo.User");
            DropIndex("dbo.BacklogItem", new[] { "OwnerId" });
            DropTable("dbo.User");
            DropTable("dbo.BacklogItem");
        }
    }
}
