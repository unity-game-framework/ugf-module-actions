using System;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UGF.Description.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public abstract class ActionSystemDescribed<TDescription> : ActionSystem, IDescribed<TDescription> where TDescription : class, IDescription
    {
        public TDescription Description { get; }
        public IApplication Application { get; }

        protected ActionSystemDescribed(TDescription description, IApplication application)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Application = application ?? throw new ArgumentNullException(nameof(application));
        }

        public T GetDescription<T>() where T : class, IDescription
        {
            return (T)GetDescription();
        }

        public IDescription GetDescription()
        {
            return Description;
        }
    }
}
