using System.Collections.Generic;
using UGF.Application.Runtime;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UGF.Module.Update.Runtime;
using UnityEngine;

namespace UGF.Module.Actions.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Actions/Action System Update", order = 2000)]
    public class ActionSystemUpdateAsset : ActionSystemDescribedAsset<ActionSystemUpdate, ActionSystemUpdateDescription>
    {
        [AssetId(typeof(UpdateGroupAsset))]
        [SerializeField] private GlobalId m_updateGroup;
        [SerializeField] private List<AssetIdReference<ActionAsset>> m_actions = new List<AssetIdReference<ActionAsset>>();

        public GlobalId UpdateGroup { get { return m_updateGroup; } set { m_updateGroup = value; } }
        public List<AssetIdReference<ActionAsset>> Actions { get { return m_actions; } }

        protected override ActionSystemUpdateDescription OnBuildDescription()
        {
            var description = new ActionSystemUpdateDescription
            {
                UpdateGroupId = m_updateGroup
            };

            for (int i = 0; i < m_actions.Count; i++)
            {
                AssetIdReference<ActionAsset> reference = m_actions[i];

                description.Actions.Add(reference.Guid, reference.Asset);
            }

            return description;
        }

        protected override ActionSystemUpdate OnBuild(ActionSystemUpdateDescription description, IApplication application)
        {
            return new ActionSystemUpdate(description, application);
        }
    }
}
