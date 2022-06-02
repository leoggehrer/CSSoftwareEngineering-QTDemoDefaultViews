using Microsoft.AspNetCore.Mvc;
using QTDemoDefaultViews.Logic;
using QTDemoDefaultViews.Logic.Entities;

namespace QTDemoDefaultViews.WebApi.Controllers
{
    /// <summary>
    /// This controller further delegates the calls to the controller instance of the logic
    /// </summary>
    public class PersonsController : GenericController<Logic.Entities.Person, Models.EditPerson, Models.Person>
    {
        /// <summary>
        /// Creates a delegate instance
        /// </summary>
        /// <param name="dataAccess"></param>
        public PersonsController(IDataAccess<Person> dataAccess) : base(dataAccess)
        {
        }

        /// <summary>
        /// Gets a filtered list of persons
        /// </summary>
        /// <param name="firstName">Optional filter for firstName</param>
        /// <param name="lastName">Optional filter for lastName</param>
        /// <returns>
        /// List of persons by given filter parameters.
        /// </returns>
        [HttpGet("query", Name = nameof(QueryAsync))]
        public async Task<ActionResult<IEnumerable<Models.Person>>> QueryAsync(
            [FromQuery(Name = "firstName")] string? firstName,
            [FromQuery(Name = "lastName")] string? lastName)
        {

            var instanceAccess = DataAccess as Logic.Controllers.PersonsController;

            return Ok(ToOutModel(await instanceAccess!.QueryByAsync(firstName, lastName)));
        }
    }
}
