using UGF.Actions.Runtime;
using UGF.Update.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public interface IActionUpdateGroup : IUpdateGroup<IActionSystem>
    {
        IActionProvider Provider { get; }
        IActionContext Context { get; }
    }
}
