using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Module.Actions.Runtime.Provider
{
    public class ProviderApplyQueueAction : ActionApplication
    {
        protected IActionModule ActionModule { get; }

        public ProviderApplyQueueAction(IApplication application) : base(application)
        {
            ActionModule = Application.GetModule<IActionModule>();
        }

        protected override void OnExecute(IActionProvider provider, IContext context)
        {
            ActionModule.Provider.ApplyQueued();
        }
    }
}
