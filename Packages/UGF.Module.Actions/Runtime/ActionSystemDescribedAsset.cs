using System;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UGF.Builder.Runtime;
using UGF.Description.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public abstract class ActionSystemDescribedAsset<TSystem, TDescription> : ActionSystemAsset, IDescribedBuilder<IApplication>, IDescriptionBuilder
        where TSystem : class, IActionSystem
        where TDescription : class, IDescription
    {
        protected override IActionSystem OnBuild(IApplication arguments)
        {
            TDescription description = OnBuildDescription();

            if (description == null) throw new ArgumentNullException(nameof(description), "Description can not be null.");

            return OnBuild(description, arguments);
        }

        protected abstract TDescription OnBuildDescription();
        protected abstract TSystem OnBuild(TDescription description, IApplication application);

        T IBuilder<IApplication, IDescribed>.Build<T>(IApplication arguments)
        {
            return (T)OnBuild(arguments);
        }

        IDescribed IBuilder<IApplication, IDescribed>.Build(IApplication arguments)
        {
            return (IDescribed)OnBuild(arguments);
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
