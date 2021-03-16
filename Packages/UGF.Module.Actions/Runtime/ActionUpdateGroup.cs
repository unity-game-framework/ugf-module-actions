using System;
using UGF.Actions.Runtime;
using UGF.Module.Update.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UGF.Update.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public class ActionUpdateGroup<TDescription> : UpdateGroupDescribed<IActionSystem, TDescription>, IActionUpdateGroup where TDescription : class, IUpdateGroupDescription
    {
        public IActionProvider Provider { get; }
        public IContext Context { get; }

        public ActionUpdateGroup(string name, TDescription description, IActionProvider provider, IContext context)
            : this(name, new UpdateSetHandler<IActionSystem>(item => item.Execute(provider, context)), description, provider, context)
        {
        }

        public ActionUpdateGroup(string name, IUpdateCollection<IActionSystem> collection, TDescription description, IActionProvider provider, IContext context) : base(name, collection, description)
        {
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
