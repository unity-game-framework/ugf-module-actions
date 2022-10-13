using System.Collections.Generic;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UGF.Builder.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Actions.Runtime
{
    public class ActionModuleDescription : ApplicationModuleDescription, IActionModuleDescription
    {
        public Dictionary<GlobalId, IBuilder<IApplication, IActionSystem>> Systems { get; } = new Dictionary<GlobalId, IBuilder<IApplication, IActionSystem>>();

        IReadOnlyDictionary<GlobalId, IBuilder<IApplication, IActionSystem>> IActionModuleDescription.Systems { get { return Systems; } }
    }
}
