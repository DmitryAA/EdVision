namespace EdVision.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12345 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Mentors", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Mentors", new[] { "CompanyId" });
            AlterColumn("dbo.Mentors", "CompanyId", c => c.Int());
            CreateIndex("dbo.Mentors", "CompanyId");
            AddForeignKey("dbo.Mentors", "CompanyId", "dbo.Companies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mentors", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Mentors", new[] { "CompanyId" });
            AlterColumn("dbo.Mentors", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Mentors", "CompanyId");
            AddForeignKey("dbo.Mentors", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
        }
    }
}
