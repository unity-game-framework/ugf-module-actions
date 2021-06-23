using System;
using UGF.Actions.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UGF.Update.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public class ActionSystemUpdatable : ActionSystem, IUpdateHandler
    {
        public IActionProvider Provider { get; }
        public IContext Context { get; }

        public ActionSystemUpdatable(IActionProvider provider, IContext context)
        {
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Update()
        {
            Execute(Provider, Context);
        }

        void IUpdateHandler.OnUpdate()
        {
            Update();
        }
    }
}
