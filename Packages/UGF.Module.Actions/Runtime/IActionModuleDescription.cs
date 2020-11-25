using System.Collections.Generic;
using UGF.Application.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public interface IActionModuleDescription : IApplicationModuleDescription
    {
        IReadOnlyDictionary<string, IActionSystemDescription> Systems { get; }
    }
}
