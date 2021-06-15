using System.Collections.Generic;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public interface IActionModuleDescription : IApplicationModuleDescription
    {
        IReadOnlyDictionary<string, IActionSystemBuilder> Systems { get; }
    }
}
