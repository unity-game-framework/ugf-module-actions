using System.Collections.Generic;
using UGF.Actions.Runtime;
using UGF.EditorTools.Runtime.IMGUI.AssetReferences;
using UGF.EditorTools.Runtime.IMGUI.Attributes;
using UnityEngine;

namespace UGF.Module.Actions.Runtime
{
    [CreateAssetMenu(menuName = "UGF/Actions/Action System Description", order = 2000)]
    public class ActionSystemDescriptionAsset : ActionSystemDescriptionAssetBase
    {
        [AssetGuid(typeof(ActionUpdateGroupDescriptionAssetBase))]
        [SerializeField] private string m_group;
        [SerializeField] private List<AssetReference<ActionDescriptionAssetBase>> m_actions = new List<AssetReference<ActionDescriptionAssetBase>>();

        public string Group { get { return m_group; } set { m_group = value; } }
        public List<AssetReference<ActionDescriptionAssetBase>> Actions { get { return m_actions; } }

        protected override IActionSystemDescription OnBuild()
        {
            var description = new ActionSystemDescription(m_group);

            for (int i = 0; i < m_actions.Count; i++)
            {
                AssetReference<ActionDescriptionAssetBase> reference = m_actions[i];
                IActionDescription actionDescription = reference.Asset.Build();

                description.Actions.Add(reference.Guid, actionDescription);
            }

            return description;
        }
    }
}
