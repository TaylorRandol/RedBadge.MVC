namespace RedBadgeData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Task", "DueDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Task", "DueDate", c => c.DateTime(nullable: false));
        }
    }
}
