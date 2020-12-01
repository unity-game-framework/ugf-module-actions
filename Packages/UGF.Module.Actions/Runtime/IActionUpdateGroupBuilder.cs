using UGF.Actions.Runtime;
using UGF.Builder.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public interface IActionUpdateGroupBuilder : IBuilder<(IActionProvider provider, IActionContext context), IActionUpdateGroup>
    {
        IActionUpdateGroup Build(IActionProvider provider, IActionContext context);
    }
}
