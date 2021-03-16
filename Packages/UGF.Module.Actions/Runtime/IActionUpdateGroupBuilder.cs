using UGF.Actions.Runtime;
using UGF.Builder.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Module.Actions.Runtime
{
    public interface IActionUpdateGroupBuilder : IBuilder<(IActionProvider provider, IContext context), IActionUpdateGroup>
    {
        IActionUpdateGroup Build(IActionProvider provider, IContext context);
    }
}
