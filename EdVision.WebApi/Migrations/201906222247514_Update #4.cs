namespace EdVision.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "JopTitle", c => c.String());
            AddColumn("dbo.People", "AcademicTitle", c => c.String());
            DropColumn("dbo.People", "Position");
            DropColumn("dbo.People", "Position1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Position1", c => c.String());
            AddColumn("dbo.People", "Position", c => c.String());
            DropColumn("dbo.People", "AcademicTitle");
            DropColumn("dbo.People", "JopTitle");
        }
    }
}
