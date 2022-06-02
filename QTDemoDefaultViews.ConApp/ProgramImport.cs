using Bogus;

namespace QTDemoDefaultViews.ConApp
{
    partial class Program
    {
        static partial void CreateImport()
        {
            Task.Run(async () =>
            {
#if DEBUG && DEVELOP_ON
                await Logic.Modules.Database.DbManager.DeleteDatabaseAsync();
                await Logic.Modules.Database.DbManager.CreateDatabaseAsync();
#endif
                var faker = new Faker<Logic.Entities.Person>();

                faker.RuleFor(e => e.FirstName, f => f.Person.FirstName)
                     .RuleFor(e => e.LastName, f => f.Person.LastName);

                var entities = faker.Generate(10);
                using var ctrl = new Logic.Controllers.PersonsController();

                await ctrl.InsertAsync(entities);
                await ctrl.SaveChangesAsync();
            }).Wait();
        }
    }
}
