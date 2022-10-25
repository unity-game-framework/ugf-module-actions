using System;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public abstract class ActionApplication : ActionBase
    {
        public IApplication Application { get; }

        protected ActionApplication(IApplication application)
        {
            Application = application ?? throw new ArgumentNullException(nameof(application));
        }
    }
}
