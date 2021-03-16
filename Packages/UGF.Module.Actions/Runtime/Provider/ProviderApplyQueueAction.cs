using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Module.Actions.Runtime.Provider
{
    public class ProviderApplyQueueAction : ActionBase
    {
        protected override void OnExecute(IActionProvider provider, IContext context)
        {
            var application = context.Get<IApplication>();
            var module = application.GetModule<IActionModule>();

            module.Provider.ApplyQueued();
        }
    }
}
