//@CodeCopy
//MdStart

namespace QTDemoDefaultViews.Logic
{
    public partial interface IVersionable : IIdentifyable
    {
        byte[]? RowVersion { get; }
    }
}
//MdEnd
