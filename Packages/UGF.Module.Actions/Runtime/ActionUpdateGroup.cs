using System;
using UGF.Actions.Runtime;
using UGF.Update.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public class ActionUpdateGroup : UpdateGroup<IActionSystem>, IActionUpdateGroup
    {
        public IActionProvider Provider { get; }
        public IActionContext Context { get; }

        public ActionUpdateGroup(string name, IActionProvider provider, IActionContext context) : this(name, new UpdateSetHandler<IActionSystem>(item => item.Execute(provider, context)), provider, context)
        {
        }

        public ActionUpdateGroup(string name, IUpdateCollection<IActionSystem> collection, IActionProvider provider, IActionContext context) : base(name, collection)
        {
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
