using System.Collections.Generic;
using UGF.Actions.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public interface IActionSystemDescription
    {
        string UpdateGroupId { get; }
        IReadOnlyDictionary<string, IActionDescription> Actions { get; }

        T Build<T>(IActionProvider provider, IActionContext context) where T : class, IActionSystem;
        IActionSystem Build(IActionProvider provider, IActionContext context);
    }
}
