namespace EdVision.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.People", name: "Position", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.People", name: "Position1", newName: "Position");
            RenameColumn(table: "dbo.People", name: "__mig_tmp__0", newName: "Position1");
            DropColumn("dbo.Companies", "CompanyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "CompanyId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.People", name: "Position1", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.People", name: "Position", newName: "Position1");
            RenameColumn(table: "dbo.People", name: "__mig_tmp__0", newName: "Position");
        }
    }
}
