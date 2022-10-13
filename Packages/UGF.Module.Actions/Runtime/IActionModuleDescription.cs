using System.Collections.Generic;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UGF.Builder.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Actions.Runtime
{
    public interface IActionModuleDescription : IApplicationModuleDescription
    {
        IReadOnlyDictionary<GlobalId, IBuilder<IApplication, IActionSystem>> Systems { get; }
    }
}
