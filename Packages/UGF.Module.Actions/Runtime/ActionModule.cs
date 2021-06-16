using System;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Module.Actions.Runtime
{
    public class ActionModule : ApplicationModule<ActionModuleDescription>, IActionModule
    {
        public IActionProvider Provider { get; }
        public IContext Context { get; }

        IActionModuleDescription IActionModule.Description { get { return Description; } }

        public ActionModule(ActionModuleDescription description, IApplication application) : this(description, application, new ActionProvider(), new Context { application })
        {
        }

        public ActionModule(ActionModuleDescription description, IApplication application, IActionProvider provider, IContext context) : base(description, application)
        {
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}
