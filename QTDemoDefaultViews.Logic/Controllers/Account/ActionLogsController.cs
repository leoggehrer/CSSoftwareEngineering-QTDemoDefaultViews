//@CodeCopy
//MdStart
#if ACCOUNT_ON
using QTDemoDefaultViews.Logic.Entities.Logging;

namespace QTDemoDefaultViews.Logic.Controllers.Account
{
    internal sealed partial class ActionLogsController : GenericController<ActionLog>
    {
        public ActionLogsController()
        {
        }

        public ActionLogsController(ControllerObject other) : base(other)
        {
        }
    }
}
#endif
//MdEnd
