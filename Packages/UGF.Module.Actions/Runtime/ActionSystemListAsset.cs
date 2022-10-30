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
        [SerializeField] private List<ActionCollectionAsset> m_collections = new List<ActionCollectionAsset>();

        public List<AssetIdReference<ActionAsset>> Actions { get { return m_actions; } }
        public List<ActionCollectionAsset> Collections { get { return m_collections; } }

        protected override ActionSystemListDescription OnBuildDescription()
        {
            var description = new ActionSystemListDescription();

            for (int i = 0; i < m_actions.Count; i++)
            {
                AssetIdReference<ActionAsset> reference = m_actions[i];

                description.Actions.Add(reference.Guid, reference.Asset);
            }

            for (int i = 0; i < m_collections.Count; i++)
            {
                m_collections[i].GetActions(description.Actions);
            }

            return description;
        }

        protected override ActionSystemList OnBuild(ActionSystemListDescription description, IApplication application)
        {
            return new ActionSystemList(description, application);
        }
    }
}
