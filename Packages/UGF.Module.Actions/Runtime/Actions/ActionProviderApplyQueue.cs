using UGF.Actions.Runtime;
using UGF.Application.Runtime;

namespace UGF.Module.Actions.Runtime.Actions
{
    public class ActionProviderApplyQueue : ActionBase
    {
        protected override void OnExecute(IActionProvider provider, IActionContext context)
        {
            var application = context.Get<IApplication>();
            var module = application.GetModule<IActionModule>();

            module.Provider.ApplyQueued();
        }
    }
}
