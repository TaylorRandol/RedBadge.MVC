namespace RedBadgeData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Note", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Note", "UserId", c => c.Guid(nullable: false));
        }
    }
}
