using System;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public abstract class ActionApplicationDescribed<TDescription, TCommand> : ActionDescribed<TDescription, TCommand>
        where TDescription : class, IActionDescription
        where TCommand : IActionCommand
    {
        public IApplication Application { get; }

        protected ActionApplicationDescribed(TDescription description, IApplication application) : base(description)
        {
            Application = application ?? throw new ArgumentNullException(nameof(application));
        }
    }
}
