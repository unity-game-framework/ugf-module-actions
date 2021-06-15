using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Module.Actions.Runtime
{
    public interface IActionModule : IApplicationModule
    {
        new IActionModuleDescription Description { get; }
        IProvider<string, IActionSystem> Systems { get; }
        IActionProvider Provider { get; }
        IContext Context { get; }
    }
}
