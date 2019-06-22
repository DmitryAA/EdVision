namespace EdVision.WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Coordinates = c.String(),
                        MeanIncome = c.Double(nullable: false),
                        MeanExpenses = c.Double(nullable: false),
                        HappinessIndex = c.Double(nullable: false),
                        RegionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regions", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CityId = c.Int(nullable: false),
                        AddressString = c.String(),
                        Coordinates = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Link = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LegalName = c.String(),
                        Description = c.String(),
                        Rating = c.Double(nullable: false),
                        INN = c.String(),
                        ORGN = c.String(),
                        CompanyId = c.Int(nullable: false),
                        address_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.address_id)
                .Index(t => t.address_id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PatronimicName = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        Position = c.String(),
                        CompanyId = c.Int(),
                        AcademicDegree = c.String(),
                        Position1 = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        address_id = c.Int(nullable: false),
                        Direction_Id = c.Int(),
                        department_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.address_id)
                .ForeignKey("dbo.EducationDirections", t => t.Direction_Id)
                .ForeignKey("dbo.Departments", t => t.department_id)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .Index(t => t.CompanyId)
                .Index(t => t.address_id)
                .Index(t => t.Direction_Id)
                .Index(t => t.department_id);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        Comment = c.String(),
                        grading_person_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.grading_person_id, cascadeDelete: true)
                .Index(t => t.grading_person_id);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        university_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Universities", t => t.university_id)
                .Index(t => t.university_id);
            
            CreateTable(
                "dbo.EducationDirections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortDescription = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Comment = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        Category = c.Int(nullable: false),
                        Company_Id = c.Int(),
                        Direction_Id = c.Int(),
                        department_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .ForeignKey("dbo.EducationDirections", t => t.Direction_Id)
                .ForeignKey("dbo.Departments", t => t.department_id)
                .Index(t => t.Company_Id)
                .Index(t => t.Direction_Id)
                .Index(t => t.department_id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Status = c.Int(nullable: false),
                        lecturer_grade_id = c.Int(nullable: false),
                        mentor_grade_id = c.Int(nullable: false),
                        project_id = c.Int(),
                        performing_student_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grades", t => t.lecturer_grade_id)
                .ForeignKey("dbo.Grades", t => t.mentor_grade_id)
                .ForeignKey("dbo.Projects", t => t.project_id)
                .ForeignKey("dbo.People", t => t.performing_student_id)
                .Index(t => t.lecturer_grade_id)
                .Index(t => t.mentor_grade_id)
                .Index(t => t.project_id)
                .Index(t => t.performing_student_id);
            
            CreateTable(
                "dbo.JobStatitics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        GotJoStudentNumbers = c.Int(nullable: false),
                        TotalStudentNumber = c.Int(nullable: false),
                        department_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.department_id)
                .Index(t => t.department_id);
            
            CreateTable(
                "dbo.Universities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        FederalRating = c.Double(nullable: false),
                        MeanGrants = c.Double(nullable: false),
                        HostelPrice = c.Double(),
                        address_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.address_id)
                .Index(t => t.address_id);
            
            CreateTable(
                "dbo.CourseResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EstimatedProject_Id = c.Int(),
                        lecturer_grade_id = c.Int(nullable: false),
                        mentor_grade_id = c.Int(nullable: false),
                        performing_student_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.EstimatedProject_Id)
                .ForeignKey("dbo.Grades", t => t.lecturer_grade_id)
                .ForeignKey("dbo.Grades", t => t.mentor_grade_id)
                .ForeignKey("dbo.People", t => t.performing_student_id)
                .Index(t => t.EstimatedProject_Id)
                .Index(t => t.lecturer_grade_id)
                .Index(t => t.mentor_grade_id)
                .Index(t => t.performing_student_id);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DepartementsToEducationDirectionsMappings",
                c => new
                    {
                        department_id = c.Int(nullable: false),
                        education_directions_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.department_id, t.education_directions_id })
                .ForeignKey("dbo.Departments", t => t.department_id, cascadeDelete: true)
                .ForeignKey("dbo.EducationDirections", t => t.education_directions_id, cascadeDelete: true)
                .Index(t => t.department_id)
                .Index(t => t.education_directions_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.People", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Grades", "grading_person_id", "dbo.People");
            DropForeignKey("dbo.Tasks", "performing_student_id", "dbo.People");
            DropForeignKey("dbo.CourseResults", "performing_student_id", "dbo.People");
            DropForeignKey("dbo.CourseResults", "mentor_grade_id", "dbo.Grades");
            DropForeignKey("dbo.CourseResults", "lecturer_grade_id", "dbo.Grades");
            DropForeignKey("dbo.CourseResults", "EstimatedProject_Id", "dbo.Projects");
            DropForeignKey("dbo.Departments", "university_id", "dbo.Universities");
            DropForeignKey("dbo.Universities", "address_id", "dbo.Addresses");
            DropForeignKey("dbo.People", "department_id", "dbo.Departments");
            DropForeignKey("dbo.JobStatitics", "department_id", "dbo.Departments");
            DropForeignKey("dbo.Projects", "department_id", "dbo.Departments");
            DropForeignKey("dbo.DepartementsToEducationDirectionsMappings", "education_directions_id", "dbo.EducationDirections");
            DropForeignKey("dbo.DepartementsToEducationDirectionsMappings", "department_id", "dbo.Departments");
            DropForeignKey("dbo.People", "Direction_Id", "dbo.EducationDirections");
            DropForeignKey("dbo.Tasks", "project_id", "dbo.Projects");
            DropForeignKey("dbo.Tasks", "mentor_grade_id", "dbo.Grades");
            DropForeignKey("dbo.Tasks", "lecturer_grade_id", "dbo.Grades");
            DropForeignKey("dbo.Projects", "Direction_Id", "dbo.EducationDirections");
            DropForeignKey("dbo.Projects", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.People", "address_id", "dbo.Addresses");
            DropForeignKey("dbo.Companies", "address_id", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "CityId", "dbo.Cities");
            DropIndex("dbo.DepartementsToEducationDirectionsMappings", new[] { "education_directions_id" });
            DropIndex("dbo.DepartementsToEducationDirectionsMappings", new[] { "department_id" });
            DropIndex("dbo.CourseResults", new[] { "performing_student_id" });
            DropIndex("dbo.CourseResults", new[] { "mentor_grade_id" });
            DropIndex("dbo.CourseResults", new[] { "lecturer_grade_id" });
            DropIndex("dbo.CourseResults", new[] { "EstimatedProject_Id" });
            DropIndex("dbo.Universities", new[] { "address_id" });
            DropIndex("dbo.JobStatitics", new[] { "department_id" });
            DropIndex("dbo.Tasks", new[] { "performing_student_id" });
            DropIndex("dbo.Tasks", new[] { "project_id" });
            DropIndex("dbo.Tasks", new[] { "mentor_grade_id" });
            DropIndex("dbo.Tasks", new[] { "lecturer_grade_id" });
            DropIndex("dbo.Projects", new[] { "department_id" });
            DropIndex("dbo.Projects", new[] { "Direction_Id" });
            DropIndex("dbo.Projects", new[] { "Company_Id" });
            DropIndex("dbo.Departments", new[] { "university_id" });
            DropIndex("dbo.Grades", new[] { "grading_person_id" });
            DropIndex("dbo.People", new[] { "department_id" });
            DropIndex("dbo.People", new[] { "Direction_Id" });
            DropIndex("dbo.People", new[] { "address_id" });
            DropIndex("dbo.People", new[] { "CompanyId" });
            DropIndex("dbo.Companies", new[] { "address_id" });
            DropIndex("dbo.Addresses", new[] { "CityId" });
            DropIndex("dbo.Cities", new[] { "RegionId" });
            DropTable("dbo.DepartementsToEducationDirectionsMappings");
            DropTable("dbo.Regions");
            DropTable("dbo.CourseResults");
            DropTable("dbo.Universities");
            DropTable("dbo.JobStatitics");
            DropTable("dbo.Tasks");
            DropTable("dbo.Projects");
            DropTable("dbo.EducationDirections");
            DropTable("dbo.Departments");
            DropTable("dbo.Grades");
            DropTable("dbo.People");
            DropTable("dbo.Companies");
            DropTable("dbo.Addresses");
            DropTable("dbo.Cities");
        }
    }
}
