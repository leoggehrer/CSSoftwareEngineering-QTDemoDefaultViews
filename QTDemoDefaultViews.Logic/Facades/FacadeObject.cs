//@CodeCopy
//MdStart

using QTDemoDefaultViews.Logic.Controllers;

namespace QTDemoDefaultViews.Logic.Facades
{
    public abstract partial class FacadeObject
    {
        internal ControllerObject ControllerObject { get; private set; }

        protected FacadeObject(ControllerObject controllerObject)
        {
            ControllerObject = controllerObject;
        }
    }
}

//MdEnd
