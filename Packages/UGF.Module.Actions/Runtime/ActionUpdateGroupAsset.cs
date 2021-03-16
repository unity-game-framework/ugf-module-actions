using UGF.Actions.Runtime;
using UGF.Description.Runtime;
using UGF.Module.Update.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Module.Actions.Runtime
{
    public abstract class ActionUpdateGroupAsset : DescribedWithDescriptionBuilderAsset<(IActionProvider provider, IContext context), IActionUpdateGroup, IUpdateGroupDescription>, IActionUpdateGroupBuilder
    {
        public IActionUpdateGroup Build(IActionProvider provider, IContext context)
        {
            return OnBuild((provider, context));
        }

        protected override IActionUpdateGroup OnBuild((IActionProvider provider, IContext context) arguments, IUpdateGroupDescription description)
        {
            return OnBuild(arguments.provider, arguments.context, description);
        }

        protected abstract IActionUpdateGroup OnBuild(IActionProvider provider, IContext context, IUpdateGroupDescription description);
    }
}
