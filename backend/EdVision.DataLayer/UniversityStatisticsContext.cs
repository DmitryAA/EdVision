using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EdVision.Models;

namespace EdVision.DataLayer
{
    public class UniversityStatisticsContext : IdentityDbContext<ApplicationUser> {
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EducationDirection> EducationDirections { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturer { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<StudentTask> Tasks { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<CourseResult> CourseResults { get; set; }
        public DbSet<JobStatistics> JobStatistics { get; set; }
        public DbSet<Person> Persons { get; set; }

        public UniversityStatisticsContext(DbContextOptions options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            
            var contactEntity = modelBuilder.Entity<Contact>();
            contactEntity.HasKey(c => c.Id);

            // var addressEntity = modelBuilder.Entity<Address>();
            // addressEntity.Property(a => a.Id).ValueGeneratedOnAdd();
            // addressEntity.HasKey(a => a.Id);
            // addressEntity.HasOne(a => a.City).WithMany().HasForeignKey("CityId");

            var cityEntity = modelBuilder.Entity<City>();
            cityEntity.Property(c => c.Id).ValueGeneratedOnAdd();
            cityEntity.HasKey(c => c.Id);
            cityEntity.HasOne(c => c.Region).WithMany().HasForeignKey("RegionId");

            var companyEntity = modelBuilder.Entity<Company>();
            companyEntity.Property(c => c.Id).ValueGeneratedOnAdd();
            companyEntity.HasKey(c => c.Id);
            companyEntity.HasMany(c => c.Contacts).WithOne().HasForeignKey("CompanyId");

            var departmentEntity = modelBuilder.Entity<Department>();
            departmentEntity.Property(d => d.Id).ValueGeneratedOnAdd();
            departmentEntity.HasKey(d => d.Id);
            departmentEntity.HasMany(d => d.Directions).WithOne().HasForeignKey("EducationalDirectionId");
            departmentEntity.HasMany(d => d.Statistics).WithOne().HasForeignKey("DepartmentId");

            var gradeEntity = modelBuilder.Entity<Grade>();
            gradeEntity.Property(g => g.Id).ValueGeneratedOnAdd();
            gradeEntity.HasKey(g => g.Id);
            gradeEntity.HasOne(g => g.GradingPerson).WithMany().HasForeignKey("GradingPersonId");

            var personEntity = modelBuilder.Entity<Person>();
            personEntity.Property(p => p.Id).ValueGeneratedOnAdd();
            personEntity.HasKey(p => p.Id);
            personEntity.HasMany(p => p.Contacts).WithOne().HasForeignKey("PersonId");

            var studentEntity = modelBuilder.Entity<Student>();
            studentEntity.HasBaseType<Person>();
            studentEntity.HasMany(s => s.Tasks).WithOne().HasForeignKey("StudentId");
            studentEntity.HasMany(s => s.ProjectResults).WithOne().HasForeignKey("StudentId");

            var lecturerEntity = modelBuilder.Entity<Lecturer>();
            lecturerEntity.HasBaseType<Person>();
            //lecturerEntity.Map(m => m.MapInheritedProperties().ToTable("Lecturer"));

            var mentorEntity = modelBuilder.Entity<Mentor>();
            mentorEntity.HasBaseType<Person>();
            //mentorEntity.Map(m => m.MapInheritedProperties().ToTable("Mentors"));

            var courseResultEntity = modelBuilder.Entity<CourseResult>();
            courseResultEntity.Property(r => r.Id).ValueGeneratedOnAdd();
            courseResultEntity.HasKey(r => r.Id);
            courseResultEntity.HasOne(r => r.LecturerGrade).WithOne().HasForeignKey<CourseResult>("LecturerGradeId");
            courseResultEntity.HasOne(r => r.MentorGrade).WithOne().HasForeignKey<CourseResult>("MentorGradeId");

            var projectEntity = modelBuilder.Entity<Project>();
            projectEntity.Property(p => p.Id).ValueGeneratedOnAdd();
            projectEntity.HasKey(p => p.Id);
            projectEntity.HasMany(p => p.Tasks).WithOne().HasForeignKey(t => t.ProjectId);

            var taskEntity = modelBuilder.Entity<StudentTask>();
            taskEntity.Property(t => t.Id).ValueGeneratedOnAdd();
            taskEntity.HasKey(t => t.Id);
            taskEntity.HasOne(t => t.LecturerGrade).WithOne().HasForeignKey<StudentTask>("LecturerGradeId");
            taskEntity.HasOne(t => t.MentorGrade).WithOne().HasForeignKey<StudentTask>("MentorGradeId");

            var universityEntity = modelBuilder.Entity<University>();
            universityEntity.Property(u => u.Id).ValueGeneratedOnAdd();
            universityEntity.HasKey(u => u.Id);
            universityEntity.HasOne(u => u.City).WithMany().HasForeignKey("CityId");
            universityEntity.HasMany(u => u.Contacts).WithOne().HasForeignKey("UniversityId");
            universityEntity.HasMany(u => u.Departments).WithOne().HasForeignKey(d => d.UniversityId);
        }
    }
}
