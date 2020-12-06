using UGF.Actions.Runtime;
using UGF.Description.Runtime;
using UGF.Module.Update.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public abstract class ActionUpdateGroupAssetBase : DescribedWithDescriptionBuilderAsset<(IActionProvider provider, IActionContext context), IActionUpdateGroup, IUpdateGroupDescription>, IActionUpdateGroupBuilder
    {
        public IActionUpdateGroup Build(IActionProvider provider, IActionContext context)
        {
            return OnBuild((provider, context));
        }

        protected override IActionUpdateGroup OnBuild((IActionProvider provider, IActionContext context) arguments, IUpdateGroupDescription description)
        {
            return OnBuild(arguments.provider, arguments.context, description);
        }

        protected abstract IActionUpdateGroup OnBuild(IActionProvider provider, IActionContext context, IUpdateGroupDescription description);
    }
}
