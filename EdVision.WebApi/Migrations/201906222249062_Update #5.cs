namespace EdVision.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "JobTitle", c => c.String());
            DropColumn("dbo.People", "JopTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "JopTitle", c => c.String());
            DropColumn("dbo.People", "JobTitle");
        }
    }
}
