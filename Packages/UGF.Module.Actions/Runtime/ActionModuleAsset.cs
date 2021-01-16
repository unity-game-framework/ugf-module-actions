using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.IMGUI.AssetReferences;
using UnityEngine;

namespace UGF.Module.Actions.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Actions/Action Module", order = 2000)]
    public class ActionModuleAsset : ApplicationModuleAsset<IActionModule, ActionModuleDescription>
    {
        [SerializeField] private List<AssetReference<ActionUpdateGroupAssetBase>> m_groups = new List<AssetReference<ActionUpdateGroupAssetBase>>();
        [SerializeField] private List<AssetReference<ActionSystemAssetBase>> m_systems = new List<AssetReference<ActionSystemAssetBase>>();

        public List<AssetReference<ActionUpdateGroupAssetBase>> Groups { get { return m_groups; } }
        public List<AssetReference<ActionSystemAssetBase>> Systems { get { return m_systems; } }

        protected override IApplicationModuleDescription OnBuildDescription()
        {
            var description = new ActionModuleDescription
            {
                RegisterType = typeof(IActionModule)
            };

            for (int i = 0; i < m_groups.Count; i++)
            {
                AssetReference<ActionUpdateGroupAssetBase> reference = m_groups[i];

                description.Groups.Add(reference.Guid, reference.Asset);
            }

            for (int i = 0; i < m_systems.Count; i++)
            {
                AssetReference<ActionSystemAssetBase> reference = m_systems[i];

                description.Systems.Add(reference.Guid, reference.Asset);
            }

            return description;
        }

        protected override IActionModule OnBuild(ActionModuleDescription description, IApplication application)
        {
            return new ActionModule(description, application);
        }
    }
}
