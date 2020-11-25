using System.Collections.Generic;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public class ActionModuleDescription : ApplicationModuleDescriptionBase, IActionModuleDescription
    {
        public Dictionary<string, IActionUpdateGroupDescription> Groups { get; } = new Dictionary<string, IActionUpdateGroupDescription>();
        public Dictionary<string, IActionSystemDescription> Systems { get; } = new Dictionary<string, IActionSystemDescription>();

        IReadOnlyDictionary<string, IActionUpdateGroupDescription> IActionModuleDescription.Groups { get { return Groups; } }
        IReadOnlyDictionary<string, IActionSystemDescription> IActionModuleDescription.Systems { get { return Systems; } }
    }
}
