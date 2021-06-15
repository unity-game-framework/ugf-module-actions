using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UGF.Module.Update.Runtime;
using UGF.Update.Runtime;
using UnityEngine;

namespace UGF.Module.Actions.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Actions/Action Update Group", order = 2000)]
    public class ActionUpdateGroupAsset : UpdateGroupAsset<IActionSystem, IUpdateGroupDescription>
    {
        protected override IUpdateCollection OnBuildCollection(IUpdateGroupDescription description, IApplication application)
        {
            var actionModule = application.GetModule<IActionModule>();

            return new UpdateListHandler<IActionSystem>(item => item.Execute(actionModule.Provider, actionModule.Context));
        }
    }
}
