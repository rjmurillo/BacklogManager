namespace BacklogManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class AddedCreatedDatetomodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BacklogItem", "CreatedDate", c => c.DateTimeOffset(nullable: false, precision: 7, defaultValue: DateTimeOffset.UtcNow));
        }

        public override void Down()
        {
            DropColumn("dbo.BacklogItem", "CreatedDate");
        }
    }
}
