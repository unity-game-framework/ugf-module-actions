using UGF.Actions.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public class ActionUpdateGroupDescription : ActionUpdateGroupDescriptionBase
    {
        public ActionUpdateGroupDescription(string updateGroupId, string name) : base(updateGroupId, name)
        {
        }

        protected override IActionUpdateGroup OnBuild(IActionProvider provider, IActionContext context)
        {
            return new ActionUpdateGroup(Name, provider, context);
        }
    }
}
