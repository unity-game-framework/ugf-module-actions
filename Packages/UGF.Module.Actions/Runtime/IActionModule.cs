using System.Collections.Generic;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public interface IActionModule : IApplicationModuleDescribed<IActionModuleDescription>
    {
        IActionProvider Provider { get; }
        IActionContext Context { get; }
        IReadOnlyDictionary<string, IActionUpdateGroupDescription> Groups { get; }
        IReadOnlyDictionary<string, IActionSystemDescription> Systems { get; }

        void AddGroup(string id, IActionUpdateGroupDescription description);
        bool RemoveGroup(string id);
        T GetGroup<T>(string id) where T : class, IActionUpdateGroup;
        IActionUpdateGroup GetGroup(string id);
        bool TryGetGroup<T>(string id, out T group) where T : class, IActionUpdateGroup;
        bool TryGetGroup(string id, out IActionUpdateGroup group);
        void AddSystem(string id, IActionSystemDescription description);
        bool RemoveSystem(string id);
        T GetSystem<T>(string id) where T : class, IActionSystem;
        IActionSystem GetSystem(string id);
        bool TryGetSystem<T>(string id, out T system) where T : class, IActionSystem;
        bool TryGetSystem(string id, out IActionSystem system);
    }
}
