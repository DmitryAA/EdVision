using System.Threading.Tasks;
using EdVision.Models;

namespace EdVision.DataLayer {
    public static class SeedData {
        public static async Task Initialize(UniversityStatisticsContext context) {
            await context.Companies.AddAsync(new Company {
                Name = "DevExpress"
            });
            await context.Companies.AddAsync(new Company {
                Name = "СиПроВер"
            });
            await context.Companies.AddAsync(new Company {
                Name = "Smartech"
            });

            var tsu = new University {
                Name = "ТулГУ"
            };
            await context.Universities.AddAsync(tsu);
            tsu.Departments.Add(new Department { Name = "Институт высокоточных систем им. В.П. Грязева" });
            tsu.Departments.Add(new Department { Name = "Политехнический институт" });
            tsu.Departments.Add(new Department { Name = "Институт прикладной математики и компьютерных наук" });
            tsu.Departments.Add(new Department { Name = "Институт горного дела и строительства" });
            tsu.Departments.Add(new Department { Name = "Естественно-научный институт" });
            tsu.Departments.Add(new Department { Name = "Институт гуманитарных и социальных наук" });
            
            var tspu = new University {
                Name = "ТГПУ"
            };
            await context.Universities.AddAsync(tspu);
            tspu.Departments.Add(new Department { Name = "Факультет математики, физики, и информатики" });
            tspu.Departments.Add(new Department { Name = "Факультет иностранных языков" });
            tspu.Departments.Add(new Department { Name = "Факультет русской филологии и документоведения" });
            tspu.Departments.Add(new Department { Name = "Факультет истории и права" });
            tspu.Departments.Add(new Department { Name = "Факультет психологии" });
            tspu.Departments.Add(new Department { Name = "Факультет технологий и бизнеса" });

            context.SaveChanges();
        }
    }
}