using System;
using System.Collections.Generic;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public class ActionModuleDescription : ApplicationModuleDescription, IActionModuleDescription
    {
        public Dictionary<string, IActionUpdateGroupBuilder> Groups { get; } = new Dictionary<string, IActionUpdateGroupBuilder>();
        public Dictionary<string, IActionSystemBuilder> Systems { get; } = new Dictionary<string, IActionSystemBuilder>();

        IReadOnlyDictionary<string, IActionUpdateGroupBuilder> IActionModuleDescription.Groups { get { return Groups; } }
        IReadOnlyDictionary<string, IActionSystemBuilder> IActionModuleDescription.Systems { get { return Systems; } }

        public ActionModuleDescription(Type registerType) : base(registerType)
        {
        }
    }
}
