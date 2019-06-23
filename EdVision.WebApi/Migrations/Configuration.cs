namespace EdVision.WebApi.Migrations
{
    using EdVision.WebApi.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EdVision.WebApi.Model.MentoringContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EdVision.WebApi.Model.MentoringContext";
        }

        protected override void Seed(EdVision.WebApi.Model.MentoringContext context) {
            var region = new Region { Name = "Тульская область" };
            context.Regions.Add(region);

            var tulaCity = new City { Name = "Тула", Region = region, HappinessIndex = 66, MeanExpenses = 40000, MeanIncome = 35000 };

            var tsuAddress = new Address { City = tulaCity };
            var tsu = new University() {
                Name = "ТулГУ", Address = tsuAddress, HostelPrice = 2000, MeanGrants = 1800, FederalRating = 4.4
            };

            var boringCompany = new Company { Name = "The Boring Company", Rating = 100 };

            var ibDepartment = new Department { Name = "ИБ" };
            tsu.Departments.Add(ibDepartment);
            context.Departments.Add(ibDepartment);

            var direction = new EducationDirection { Name = "Математика и инорматика" };
            ibDepartment.Directions.Add(direction);
            context.EducationDirections.Add(direction);

            var student = new Student {
                FirstName = "Ivan",
                LastName = "Ivanov",
                PatronimicName = "Ivanovich",
            };
            direction.Students.Add(student);
            context.Students.Add(student);

            var lecturer = new Lecturer { FirstName = "Sidor", LastName = "Sidorov", PatronimicName = "Sidorovich" };
            context.Lecturer.Add(lecturer);

            var mentor = new Mentor { FirstName = "Vasiliy", LastName = "Vasiliev", PatronimicName = "Vasilievich" };
            context.Mentors.Add(mentor);

            var project = new Project {
                Name = "Hacathon",
                Company = boringCompany,
                Category = ProjectCategory.Investigation,
                StartDate = DateTime.Now,
                EndDate = null,
            };
            direction.Projects.Add(project);
            context.Projects.Add(project);

            var task = new Task {
                Name = "Win",
                EndDate = DateTime.Now.AddDays(1),
                StartDate = DateTime.Now,
                Status = TaskStatus.InProgress,
                Performer = student,
                LecturerGrade = new Grade {
                    Comment = "Good",
                    Value = 81,
                    GradingPerson = lecturer
                },
                MentorGrade = new Grade {
                    Comment = "Very Good",
                    Value = 81,
                    GradingPerson = mentor
                }
            };
            project.Tasks.Add(task);
            context.Tasks.Add(task);

            context.SaveChanges();
        }
    }
}
