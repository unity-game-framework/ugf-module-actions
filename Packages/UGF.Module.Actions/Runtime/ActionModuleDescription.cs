using System.Collections.Generic;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public class ActionModuleDescription : ApplicationModuleDescription, IActionModuleDescription
    {
        public Dictionary<string, IActionSystemBuilder> Systems { get; } = new Dictionary<string, IActionSystemBuilder>();

        IReadOnlyDictionary<string, IActionSystemBuilder> IActionModuleDescription.Systems { get { return Systems; } }
    }
}
