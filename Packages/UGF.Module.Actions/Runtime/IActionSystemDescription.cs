using System.Collections.Generic;
using UGF.Actions.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public interface IActionSystemDescription
    {
        string GroupId { get; }
        IReadOnlyDictionary<string, IActionDescription> Actions { get; }

        T Build<T>() where T : class, IActionSystem;
        IActionSystem Build();
    }
}
