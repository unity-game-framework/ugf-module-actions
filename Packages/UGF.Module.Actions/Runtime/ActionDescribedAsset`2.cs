using System;
using UGF.Actions.Runtime;
using UGF.Builder.Runtime;
using UGF.Description.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public abstract class ActionDescribedAsset<TDescribed, TDescription> : ActionAssetBase, IDescribedBuilder, IDescriptionBuilder
        where TDescribed : class, IAction, IDescribed
        where TDescription : class, IActionDescription
    {
        protected override IAction OnBuild()
        {
            TDescription description = OnBuildDescription();

            if (description == null) throw new ArgumentNullException(nameof(description), "Description can not be null.");

            return OnBuild(description);
        }

        protected abstract TDescription OnBuildDescription();
        protected abstract TDescribed OnBuild(TDescription description);

        T IBuilder<IDescribed>.Build<T>()
        {
            return (T)OnBuild();
        }

        IDescribed IBuilder<IDescribed>.Build()
        {
            return (IDescribed)OnBuild();
        }

        T IBuilder<IDescription>.Build<T>()
        {
            return (T)(object)OnBuildDescription();
        }

        IDescription IBuilder<IDescription>.Build()
        {
            return OnBuildDescription();
        }
    }
}
