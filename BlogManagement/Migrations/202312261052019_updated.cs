namespace BlogManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updated : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "ActionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "ActionId", c => c.Int(nullable: false));
        }
    }
}
