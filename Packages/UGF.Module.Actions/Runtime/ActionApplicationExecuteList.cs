using System;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public abstract class ActionApplicationExecuteList : ActionExecuteList
    {
        public IApplication Application { get; }

        protected ActionApplicationExecuteList(IApplication application)
        {
            Application = application ?? throw new ArgumentNullException(nameof(application));
        }
    }
}
