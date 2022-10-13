using System;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public abstract class Action<TDescription> : ActionDescribed<TDescription> where TDescription : class, IActionDescription
    {
        public IApplication Application { get; }

        protected Action(TDescription description, IApplication application) : base(description)
        {
            Application = application ?? throw new ArgumentNullException(nameof(application));
        }
    }
}
