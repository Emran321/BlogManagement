namespace BlogManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newfieldadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "ActionId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "ActionId");
        }
    }
}
