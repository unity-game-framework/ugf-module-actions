using System.Collections.Generic;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public interface IActionModule : IApplicationModule
    {
        new IActionModuleDescription Description { get; }
        IActionProvider Provider { get; }
        IActionContext Context { get; }
        IReadOnlyDictionary<string, IActionUpdateGroup> Groups { get; }
        IReadOnlyDictionary<string, IActionSystemDescribed> Systems { get; }

        void AddGroup(string id, IActionUpdateGroup group);
        bool RemoveGroup(string id);
        void AddSystem(string id, IActionSystemDescribed system);
        bool RemoveSystem(string id);
        T GetGroup<T>(string id) where T : class, IActionUpdateGroup;
        IActionUpdateGroup GetGroup(string id);
        bool TryGetGroup<T>(string id, out T group) where T : class, IActionUpdateGroup;
        bool TryGetGroup(string id, out IActionUpdateGroup group);
        T GetSystem<T>(string id) where T : class, IActionSystemDescribed;
        IActionSystemDescribed GetSystem(string id);
        bool TryGetSystem<T>(string id, out T system) where T : class, IActionSystemDescribed;
        bool TryGetSystem(string id, out IActionSystemDescribed system);
    }
}
