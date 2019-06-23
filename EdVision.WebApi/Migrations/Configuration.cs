namespace EdVision.WebApi.Migrations
{
    using EdVision.WebApi.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EdVision.WebApi.Model.MentoringContext>
    {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
            ContextKey = "EdVision.WebApi.Model.MentoringContext";
        }

        protected override void Seed(EdVision.WebApi.Model.MentoringContext context) {
            //var region = new Region { Name = "Тульская область" };
            //context.Regions.Add(region);
            //context.SaveChanges();

            //var tulaCity = new City { Name = "Тула", Region = region, HappinessIndex = 66, MeanExpenses = 40000, MeanIncome = 35000 };
            //context.Cities.Add(tulaCity);
            //context.SaveChanges();

            //var tsuAddress = new Address { City = tulaCity };
            //context.Addresses.Add(tsuAddress);
            //var studentAddress = new Address { City = tulaCity };
            //context.Addresses.Add(studentAddress);
            //var mentorAddress = new Address { City = tulaCity };
            //context.Addresses.Add(mentorAddress);
            //var lecturerAddress = new Address { City = tulaCity };
            //context.Addresses.Add(lecturerAddress);
            //var companyAddress = new Address { City = tulaCity };
            //context.Addresses.Add(companyAddress);
            //context.SaveChanges();

            //var tsu = new University() {
            //    Name = "ТулГУ",
            //    Address = tsuAddress,
            //    HostelPrice = 2000,
            //    MeanGrants = 1800,
            //    FederalRating = 4.4
            //};
            //context.Universities.Add(tsu);
            //context.SaveChanges();

            //var boringCompany = new Company { Name = "The Boring Company", Rating = 100, Address = companyAddress };
            //context.Companies.Add(boringCompany);
            //context.SaveChanges();

            //var ibDepartment = new Department { Name = "ИБ" };
            //tsu.Departments.Add(ibDepartment);
            //context.Departments.Add(ibDepartment);
            //context.SaveChanges();

            //var direction = new EducationDirection { Name = "Математика и инорматика" };
            //ibDepartment.Directions.Add(direction);
            //context.EducationDirections.Add(direction);
            //context.SaveChanges();

            //var student = new Student {
            //    FirstName = "Ivan",
            //    LastName = "Ivanov",
            //    PatronimicName = "Ivanovich",
            //    Address = studentAddress,
            //};
            //direction.Students.Add(student);
            //context.Students.Add(student);
            //try {
            //    context.SaveChanges();
            //} catch (Exception e) {
            //    Console.Write(e.Message);
            //}

            //var lecturer = new Lecturer { FirstName = "Sidor", LastName = "Sidorov", PatronimicName = "Sidorovich", Address = lecturerAddress };
            //context.Lecturer.Add(lecturer);
            //context.SaveChanges();

            //var mentor = new Mentor { FirstName = "Vasiliy", LastName = "Vasiliev", PatronimicName = "Vasilievich", Address = mentorAddress };
            //boringCompany.Mentors.Add(mentor);
            //context.Mentors.Add(mentor);
            //context.SaveChanges();

            //var project = new Project {
            //    Name = "Hackathon",
            //    Company = boringCompany,
            //    Category = ProjectCategory.Investigation,
            //    StartDate = DateTime.Now,
            //    EndDate = DateTime.MaxValue,
            //};
            //direction.Projects.Add(project);
            //context.Projects.Add(project);
            //context.SaveChanges();

            //var lecturerGrade = new Grade {
            //    Comment = "Good",
            //    Value = 81,
            //    GradingPerson = lecturer
            //};
            //context.Grades.Add(lecturerGrade);
            //var mentorGrade = new Grade {
            //    Comment = "Very Good",
            //    Value = 81,
            //    GradingPerson = mentor
            //};
            //context.Grades.Add(mentorGrade);
            //context.SaveChanges();

            //var task = new Task {
            //    Name = "Win",
            //    EndDate = DateTime.Now.AddDays(1),
            //    StartDate = DateTime.Now,
            //    Status = TaskStatus.InProgress,
            //    Performer = student,
            //    LecturerGrade = lecturerGrade,
            //    MentorGrade = mentorGrade
            //};
            //project.Tasks.Add(task);
            //context.Tasks.Add(task);
            //context.SaveChanges();
            
            var city = context.Cities.FirstOrDefault();
            var direction = context.EducationDirections.FirstOrDefault();
            var mentor = context.Mentors.FirstOrDefault();
            var lecturer = context.Lecturer.FirstOrDefault();

            var address1 = new Address { City = city };
            context.Addresses.Add(address1);
            var address2 = new Address { City = city };
            context.Addresses.Add(address2);

            var student1 = new Student { FirstName = "Kirill", LastName = "Kirillov", PatronimicName = "Kirillovich", Address = address1 };
            direction.Students.Add(student1);
            context.Students.Add(student1);
            var student2 = new Student { FirstName = "Dennis", LastName = "Dennisov", PatronimicName = "Dennisovich", Address = address2 };
            direction.Students.Add(student2);
            context.Students.Add(student2);

            var task1_1 = new Task {
                Name = "Make the Hackthon Great Again!",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                Status = TaskStatus.Approved,
                LecturerGrade = new Grade {
                    GradingPerson = lecturer,
                    Comment = "You'll made it.",
                    Value = 69
                },
                MentorGrade = new Grade {
                    Comment = "I don't think so.",
                    GradingPerson = mentor,
                    Value = 71
                }
            };
            student1.Tasks.Add(task1_1);
            context.Tasks.Add(task1_1);

            var task1_2 = new Task {
                Name = "Write over 9000 lines of code!",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                Status = TaskStatus.Approved,
                LecturerGrade = new Grade {
                    GradingPerson = lecturer,
                    Comment = "Wasted!",
                    Value = 50
                },
                MentorGrade = new Grade {
                    Comment = "Let the code be with you.",
                    GradingPerson = mentor,
                    Value = 74
                }
            };
            student1.Tasks.Add(task1_2);
            context.Tasks.Add(task1_2);


            var task2_1 = new Task {
                Name = "Design the greed product.",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(2),
                Status = TaskStatus.Approved,
                LecturerGrade = new Grade {
                    GradingPerson = lecturer,
                    Comment = "Shut up and take my money!",
                    Value = 80
                },
                MentorGrade = new Grade {
                    Comment = "My tressure.",
                    GradingPerson = mentor,
                    Value = 61
                }
            };
            student1.Tasks.Add(task2_1);
            context.Tasks.Add(task2_1);

            var task2_2 = new Task {
                Name = "Win, or loose, just have fun!",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(2),
                Status = TaskStatus.Approved,
                LecturerGrade = new Grade {
                    GradingPerson = lecturer,
                    Comment = "Have a nice day!.",
                    Value = 95
                },
                MentorGrade = new Grade {
                    Comment = "Chill, bro.",
                    GradingPerson = mentor,
                    Value = 99
                }
            };
            student1.Tasks.Add(task2_2);
            context.Tasks.Add(task2_2);

            context.SaveChanges();
        }
    }
}
