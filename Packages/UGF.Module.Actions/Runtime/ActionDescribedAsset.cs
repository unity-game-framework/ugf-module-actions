using System;
using UGF.Actions.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public abstract class ActionDescribedAsset<TDescription> : ActionAssetBase where TDescription : IActionDescription
    {
        protected override IAction OnBuild()
        {
            TDescription description = OnBuildDescription();

            if (description == null) throw new ArgumentNullException(nameof(description), "Description can not be null.");

            return OnBuild(description);
        }

        protected abstract TDescription OnBuildDescription();
        protected abstract IAction OnBuild(TDescription description);
    }
}
