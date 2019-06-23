namespace EdVision.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1234 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "Birthday", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Birthday", c => c.DateTime(nullable: false));
        }
    }
}
