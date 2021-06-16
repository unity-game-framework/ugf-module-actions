using UGF.Application.Runtime;
using UnityEngine;

namespace UGF.Module.Actions.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Actions/Action Module", order = 2000)]
    public class ActionModuleAsset : ApplicationModuleAsset<IActionModule, ActionModuleDescription>
    {
        protected override IApplicationModuleDescription OnBuildDescription()
        {
            var description = new ActionModuleDescription
            {
                RegisterType = typeof(IActionModule)
            };

            return description;
        }

        protected override IActionModule OnBuild(ActionModuleDescription description, IApplication application)
        {
            return new ActionModule(description, application);
        }
    }
}
