using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UGF.Update.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public interface IActionModule : IApplicationModule
    {
        new IActionModuleDescription Description { get; }
        IActionProvider Provider { get; }
        IContext Context { get; }
        IUpdateGroup ProviderApplyQueueUpdateGroup { get; }
        bool HasProviderApplyQueueUpdateGroup { get; }
    }
}
