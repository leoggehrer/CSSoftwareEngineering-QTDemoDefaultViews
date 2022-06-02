namespace QTDemoDefaultViews.Logic.Controllers
{
    public sealed partial class PersonsController : GenericController<Entities.Person>
    {
        public PersonsController()
        {
        }

        public PersonsController(ControllerObject other) : base(other)
        {
        }

        public Task<Entities.Person[]> QueryByAsync(string? firstName, string? lastName)
        {
            var query = EntitySet.AsQueryable();

            if (firstName != null)
            {
                query = query.Where(e => e.FirstName.Contains(firstName));
            }
            if (lastName != null)
            {
                query = query.Where(e => e.LastName.Contains(lastName));
            }
            return query.AsNoTracking().ToArrayAsync();
        }
    }
}
