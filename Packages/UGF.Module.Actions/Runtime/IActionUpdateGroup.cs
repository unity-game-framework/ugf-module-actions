using UGF.Actions.Runtime;
using UGF.Module.Update.Runtime;
using UGF.Update.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public interface IActionUpdateGroup : IUpdateGroupDescribed, IUpdateGroup<IActionSystem>
    {
        IActionProvider Provider { get; }
        IActionContext Context { get; }
    }
}
