namespace RedBadgeData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Project", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Project", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Project", "ModifiedUtc", c => c.DateTime());
            AlterColumn("dbo.Project", "CreatedUtc", c => c.DateTime(nullable: false));
        }
    }
}
