using System.Collections.Generic;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UGF.Builder.Runtime;
using UGF.EditorTools.Runtime.Assets;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;

namespace UGF.Module.Actions.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Actions/Action Collection List", order = 2000)]
    public class ActionCollectionListAsset : ActionCollectionAsset
    {
        [SerializeField] private List<AssetIdReference<ActionAsset>> m_actions = new List<AssetIdReference<ActionAsset>>();

        public List<AssetIdReference<ActionAsset>> Actions { get { return m_actions; } }

        protected override void OnGetActions(IDictionary<GlobalId, IBuilder<IApplication, IAction>> actions)
        {
            for (int i = 0; i < m_actions.Count; i++)
            {
                AssetIdReference<ActionAsset> reference = m_actions[i];

                actions.Add(reference.Guid, reference.Asset);
            }
        }
    }
}
