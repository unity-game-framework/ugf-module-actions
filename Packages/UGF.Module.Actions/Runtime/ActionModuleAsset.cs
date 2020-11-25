using System.Collections.Generic;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.IMGUI.AssetReferences;
using UGF.Module.Update.Runtime;
using UnityEngine;

namespace UGF.Module.Actions.Runtime
{
    [CreateAssetMenu(menuName = "UGF/Actions/Action Module", order = 2000)]
    public class ActionModuleAsset : ApplicationModuleDescribedAsset<IActionModule, ActionModuleDescription>
    {
        [SerializeField] private List<AssetReference<ActionUpdateGroupDescriptionAssetBase>> m_groups = new List<AssetReference<ActionUpdateGroupDescriptionAssetBase>>();
        [SerializeField] private List<AssetReference<ActionSystemDescriptionAssetBase>> m_systems = new List<AssetReference<ActionSystemDescriptionAssetBase>>();

        public List<AssetReference<ActionUpdateGroupDescriptionAssetBase>> Groups { get { return m_groups; } }
        public List<AssetReference<ActionSystemDescriptionAssetBase>> Systems { get { return m_systems; } }

        protected override ActionModuleDescription OnGetDescription(IApplication application)
        {
            var description = new ActionModuleDescription();

            for (int i = 0; i < m_groups.Count; i++)
            {
                AssetReference<ActionUpdateGroupDescriptionAssetBase> reference = m_groups[i];
                IActionUpdateGroupDescription groupDescription = reference.Asset.Build();

                description.Groups.Add(reference.Guid, groupDescription);
            }

            for (int i = 0; i < m_systems.Count; i++)
            {
                AssetReference<ActionSystemDescriptionAssetBase> reference = m_systems[i];
                IActionSystemDescription systemDescription = reference.Asset.Build();

                description.Systems.Add(reference.Guid, systemDescription);
            }

            return description;
        }

        protected override IActionModule OnBuild(IApplication application, ActionModuleDescription description)
        {
            var updateModule = application.GetModule<IUpdateModule>();

            return new ActionModule(application, description, updateModule);
        }
    }
}
