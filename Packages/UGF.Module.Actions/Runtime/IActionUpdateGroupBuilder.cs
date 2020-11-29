using UGF.Actions.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public interface IActionUpdateGroupBuilder
    {
        T Build<T>(IActionProvider provider, IActionContext context) where T : class, IActionUpdateGroup;
        IActionUpdateGroup Build(IActionProvider provider, IActionContext context);
    }
}
