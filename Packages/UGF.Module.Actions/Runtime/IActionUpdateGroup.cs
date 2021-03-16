using UGF.Actions.Runtime;
using UGF.Description.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UGF.Update.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public interface IActionUpdateGroup : IUpdateGroup<IActionSystem>, IDescribed
    {
        IActionProvider Provider { get; }
        IContext Context { get; }
    }
}
