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
            context.SaveChanges();
        }
    }
}