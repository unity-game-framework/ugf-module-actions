using System.Collections.Generic;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public interface IActionModule : IApplicationModuleDescribed<IActionModuleDescription>
    {
        IActionProvider Provider { get; }
        IActionContext Context { get; }
        IReadOnlyDictionary<string, IActionSystem> Systems { get; }

        T GetSystem<T>(string id) where T : class, IActionSystem;
        IActionSystem GetSystem(string id);
        bool TryGetSystem<T>(string id, out T system) where T : class, IActionSystem;
        bool TryGetSystem(string id, out IActionSystem system);
    }
}
