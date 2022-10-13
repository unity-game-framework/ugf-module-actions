using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Assets;
using UnityEngine;

namespace UGF.Module.Actions.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Actions/Action System List", order = 2000)]
    public class ActionSystemListAsset : ActionSystemDescribedAsset<ActionSystemList, ActionSystemListDescription>
    {
        [SerializeField] private List<AssetIdReference<ActionAsset>> m_actions = new List<AssetIdReference<ActionAsset>>();

        public List<AssetIdReference<ActionAsset>> Actions { get { return m_actions; } }

        protected override ActionSystemListDescription OnBuildDescription()
        {
            var description = new ActionSystemListDescription();

            for (int i = 0; i < m_actions.Count; i++)
            {
                AssetIdReference<ActionAsset> reference = m_actions[i];

                description.Actions.Add(reference.Guid, reference.Asset);
            }

            return description;
        }

        protected override ActionSystemList OnBuild(ActionSystemListDescription description, IApplication application)
        {
            return new ActionSystemList(description, application);
        }
    }
}
