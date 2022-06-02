using Microsoft.AspNetCore.Mvc;

namespace QTDemoDefaultViews.AspMvc.Controllers
{
    public class PersonsController : GenericController<Logic.Entities.Person, Models.Person>
    {
        private string FilterName => typeof(Models.PersonFilter).Name;
        public PersonsController(Logic.IDataAccess<Logic.Entities.Person> dataAccess) : base(dataAccess)
        {
        }

        public override async Task<IActionResult> Index()
        {
            IActionResult? result;
            var filter = SessionWrapper.Get<Models.PersonFilter>(FilterName) ?? new Models.PersonFilter();

            if (filter.HasValue)
            {
                var instanceDataAccess = DataAccess as Logic.Controllers.PersonsController;
                var accessModels = await instanceDataAccess!.QueryByAsync(filter.FirstName, filter.LastName);

                result = View(AfterQuery(accessModels).Select(e => ToViewModel(e, ActionMode.Index)));
            }
            else
            {
                var accessModels = await DataAccess.GetAllAsync();

                result = View(AfterQuery(accessModels).Select(e => ToViewModel(e, ActionMode.Index)));
            }

            ViewBag.Filter = filter;
            return result;
        }

        public async Task<IActionResult> Filter(Models.PersonFilter filter)
        {
            IActionResult? result;

            if (filter.HasValue)
            {
                var instanceDataAccess = DataAccess as Logic.Controllers.PersonsController;
                var accessModels = await instanceDataAccess!.QueryByAsync(filter.FirstName, filter.LastName);

                result = View("Index", AfterQuery(accessModels).Select(e => ToViewModel(e, ActionMode.Index)));
            }
            else
            {
                result = RedirectToAction("Index");
            }

            ViewBag.Filter = filter;
            SessionWrapper.Set<Models.PersonFilter>(FilterName, filter);
            return result;
        }
    }
}
