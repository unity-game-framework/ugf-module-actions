using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.IMGUI.Types;
using UGF.Module.Update.Runtime;
using UnityEngine;

namespace UGF.Module.Actions.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Actions/Action Module", order = 2000)]
    public class ActionModuleAsset : ApplicationModuleAsset<IActionModule, ActionModuleDescription>
    {
        [SerializeField] private bool m_providerApplyQueueUpdateGroupCreate = true;
        [UpdateSystemTypeDropdown]
        [SerializeField] private TypeReference<object> m_providerApplyQueueUpdateGroupTargetSystemType;

        public bool ProviderApplyQueueUpdateGroupCreate { get { return m_providerApplyQueueUpdateGroupCreate; } set { m_providerApplyQueueUpdateGroupCreate = value; } }
        public TypeReference<object> ProviderApplyQueueUpdateGroupTargetSystemType { get { return m_providerApplyQueueUpdateGroupTargetSystemType; } set { m_providerApplyQueueUpdateGroupTargetSystemType = value; } }

        protected override IApplicationModuleDescription OnBuildDescription()
        {
            var description = new ActionModuleDescription
            {
                RegisterType = typeof(IActionModule),
                ProviderApplyQueueUpdateGroupCreate = m_providerApplyQueueUpdateGroupCreate,
                ProviderApplyQueueUpdateGroupTargetSystemType = m_providerApplyQueueUpdateGroupTargetSystemType.Get()
            };

            return description;
        }

        protected override IActionModule OnBuild(ActionModuleDescription description, IApplication application)
        {
            return new ActionModule(description, application);
        }
    }
}
