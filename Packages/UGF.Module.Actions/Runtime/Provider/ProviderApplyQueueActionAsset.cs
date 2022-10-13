using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UnityEngine;

namespace UGF.Module.Actions.Runtime.Provider
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Actions/Actions/Provider Apply Queue Action", order = 2000)]
    public class ProviderApplyQueueActionAsset : ActionAsset
    {
        protected override IAction OnBuild(IApplication arguments)
        {
            return new ProviderApplyQueueAction(arguments);
        }
    }
}
