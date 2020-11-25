using UGF.Actions.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public interface IActionUpdateGroupDescription
    {
        string UpdateGroupId { get; }
        string Name { get; }

        T Build<T>(IActionProvider provider, IActionContext context) where T : class, IActionUpdateGroup;
        IActionUpdateGroup Build(IActionProvider provider, IActionContext context);
    }
}
