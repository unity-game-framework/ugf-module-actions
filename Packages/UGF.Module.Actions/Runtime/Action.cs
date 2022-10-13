using System;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public abstract class Action : ActionBase
    {
        public IApplication Application { get; }

        protected Action(IApplication application)
        {
            Application = application ?? throw new ArgumentNullException(nameof(application));
        }
    }
}
