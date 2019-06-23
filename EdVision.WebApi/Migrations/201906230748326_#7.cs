namespace EdVision.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tasks", "Performer_Id", "dbo.Students");
            DropIndex("dbo.Tasks", new[] { "Performer_Id" });
            DropColumn("dbo.Tasks", "Performer_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tasks", "Performer_Id", c => c.Int());
            CreateIndex("dbo.Tasks", "Performer_Id");
            AddForeignKey("dbo.Tasks", "Performer_Id", "dbo.Students", "Id");
        }
    }
}
