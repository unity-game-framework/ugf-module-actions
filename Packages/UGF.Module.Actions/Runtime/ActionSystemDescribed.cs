using System;
using UGF.Actions.Runtime;
using UGF.Description.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public class ActionSystemDescribed<TDescription> : ActionSystem, IDescribed<IActionSystemDescription> where TDescription : class, IActionSystemDescription
    {
        public TDescription Description { get; }

        IActionSystemDescription IDescribed<IActionSystemDescription>.Description { get { return Description; } }

        public ActionSystemDescribed(TDescription description)
        {
            Description = description ?? throw new ArgumentNullException(nameof(description));
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
