//@CodeCopy
//MdStart
#if ACCOUNT_ON
using Microsoft.AspNetCore.Mvc;
using QTDemoDefaultViews.Logic;
using QTDemoDefaultViews.Logic.Entities.Account;
using FilterType = QTDemoDefaultViews.AspMvc.Models.Account.RoleFilter;

namespace QTDemoDefaultViews.AspMvc.Controllers.Account
{
    public class RolesController : GenericController<Logic.Entities.Account.Role, Models.Account.Role>
    {
        private static string FilterName => typeof(FilterType).Name;
        public RolesController(IDataAccess<Logic.Entities.Account.Role> dataAccess) : base(dataAccess)
        {
        }

        protected override Role[] AfterQuery(Role[] accessModels)
        {
            return base.AfterQuery(accessModels);
        }

        public override Task<IActionResult> Index()
        {
            ViewBag.Filter = SessionWrapper.Get<FilterType>(FilterName) ?? new FilterType();

            return base.Index();
        }
        public async Task<IActionResult> Filter(FilterType filter)
        {
            var accessModels = await DataAccess.GetAllAsync();

            ViewBag.Filter = filter;
            SessionWrapper.Set<FilterType>(FilterName, filter);
            return View("Index", AfterQuery(accessModels).Select(e => ToViewModel(e, ActionMode.Index)));
        }
    }
}
#endif
//MdEnd
