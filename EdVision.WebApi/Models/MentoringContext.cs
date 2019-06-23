﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EdVision.WebApi.Model
{
    public class MentoringContext : DbContext {
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EducationDirection> EducationDirections { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturer { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<CourseResult> CourseResults { get; set; }
        public DbSet<JobStatitics> JobStatitics { get; set; }


        public MentoringContext(): base("name=Model1") {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            var addressEntity = modelBuilder.Entity<Address>();
            addressEntity.HasRequired(a => a.City).WithMany().Map(m => m.MapKey("CityId"));// .HasForeignKey(a => a.CityId);

            modelBuilder.Entity<City>().HasRequired(c => c.Region).WithMany().Map(m => m.MapKey("RegionId"));//.HasForeignKey(c => c.RegionId);

            var companyEntity = modelBuilder.Entity<Company>();
            companyEntity.HasRequired(c => c.Address).WithOptional().Map(m => m.MapKey("address_id") );
            companyEntity.HasMany(c => c.Mentors).WithRequired(m => m.Company).Map(m => m.MapKey("CompanyId"));

            var departmentEntity = modelBuilder.Entity<Department>();
            departmentEntity.HasMany(d => d.Directions).WithMany(m => m.Departments).Map(m => m.MapLeftKey("department_id").MapRightKey("education_directions_id").ToTable("DepartementsToEducationDirectionsMappings"));
            departmentEntity.HasMany(d => d.Projects).WithOptional(p => p.Department).Map(m => m.MapKey("department_id"));
            departmentEntity.HasMany(d => d.Students).WithOptional(s => s.Department).Map(m => m.MapKey("department_id"));
            departmentEntity.HasMany(d => d.Statitics).WithOptional().Map(m => m.MapKey("department_id"));

            modelBuilder.Entity<Grade>().HasRequired(g => g.GradingPerson).WithMany().Map(m => m.MapKey("grading_person_id"));

            var personEntity = modelBuilder.Entity<Person>();
            personEntity.HasRequired(p => p.Address).WithOptional().Map(m => m.MapKey("address_id"));

            var studentEntity = modelBuilder.Entity<Student>();
            //studentEntity.Map(m => m.MapInheritedProperties().ToTable("Students"));
            studentEntity.HasMany(s => s.Tasks).WithOptional(t => t.Performer).Map(m => m.MapKey("performing_student_id"));
            studentEntity.HasMany(s => s.ProjectResults).WithOptional(r => r.Performer).Map(m => m.MapKey("performing_student_id"));
            studentEntity.HasRequired(p => p.Address).WithOptional().Map(m => m.MapKey("address_id"));


            var lecturerEntity = modelBuilder.Entity<Lecturer>();
            //lecturerEntity.Map(m => m.MapInheritedProperties().ToTable("Lecturer"));

            var mentorEntity = modelBuilder.Entity<Mentor>();
            //mentorEntity.Map(m => m.MapInheritedProperties().ToTable("Mentors"));
            //mentorEntity.HasRequired(p => p.Address).WithOptional().Map(m => m.MapKey("address_id"));

            var projectResult = modelBuilder.Entity<CourseResult>();
            projectResult.HasRequired(r => r.LecturerGrade).WithOptional().Map(m => m.MapKey("lecturer_grade_id"));
            projectResult.HasRequired(r => r.MentorGrade).WithOptional().Map(m => m.MapKey("mentor_grade_id"));

            var taskEntity = modelBuilder.Entity<Task>();
            taskEntity.HasOptional(t => t.Project).WithMany(p => p.Tasks).Map(m => m.MapKey("project_id"));
            taskEntity.HasRequired(t => t.LecturerGrade).WithOptional().Map(m => m.MapKey("lecturer_grade_id"));
            taskEntity.HasRequired(t => t.MentorGrade).WithOptional().Map(m => m.MapKey("mentor_grade_id"));

            var universityEntity = modelBuilder.Entity<University>();
            universityEntity.HasRequired(u => u.Address).WithOptional().Map(m => m.MapKey("address_id"));
            universityEntity.HasMany(u => u.Departments).WithOptional().Map(m => m.MapKey("university_id"));
        }
    }
}
