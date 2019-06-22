namespace EdVision.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updte3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CourseResults", "performing_student_id", "dbo.People");
            DropForeignKey("dbo.Tasks", "performing_student_id", "dbo.People");
            DropForeignKey("dbo.Grades", "grading_person_id", "dbo.People");
            DropPrimaryKey("dbo.People");
            AlterColumn("dbo.People", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.People", "Id");
            AddForeignKey("dbo.CourseResults", "performing_student_id", "dbo.People", "Id");
            AddForeignKey("dbo.Tasks", "performing_student_id", "dbo.People", "Id");
            AddForeignKey("dbo.Grades", "grading_person_id", "dbo.People", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grades", "grading_person_id", "dbo.People");
            DropForeignKey("dbo.Tasks", "performing_student_id", "dbo.People");
            DropForeignKey("dbo.CourseResults", "performing_student_id", "dbo.People");
            DropPrimaryKey("dbo.People");
            AlterColumn("dbo.People", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.People", "Id");
            AddForeignKey("dbo.Grades", "grading_person_id", "dbo.People", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Tasks", "performing_student_id", "dbo.People", "Id");
            AddForeignKey("dbo.CourseResults", "performing_student_id", "dbo.People", "Id");
        }
    }
}
