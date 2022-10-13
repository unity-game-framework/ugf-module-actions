using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Assets;
using UnityEngine;

namespace UGF.Module.Actions.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Actions/Action Module", order = 2000)]
    public class ActionModuleAsset : ApplicationModuleAsset<IActionModule, ActionModuleDescription>
    {
        [SerializeField] private List<AssetIdReference<ActionSystemAsset>> m_systems = new List<AssetIdReference<ActionSystemAsset>>();

        public List<AssetIdReference<ActionSystemAsset>> Systems { get { return m_systems; } }

        protected override IApplicationModuleDescription OnBuildDescription()
        {
            var description = new ActionModuleDescription
            {
                RegisterType = typeof(IActionModule)
            };

            for (int i = 0; i < m_systems.Count; i++)
            {
                AssetIdReference<ActionSystemAsset> reference = m_systems[i];

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
