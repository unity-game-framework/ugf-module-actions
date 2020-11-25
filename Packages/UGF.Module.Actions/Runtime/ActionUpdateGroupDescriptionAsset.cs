using UGF.EditorTools.Runtime.IMGUI.Attributes;
using UGF.Module.Update.Runtime;
using UnityEngine;

namespace UGF.Module.Actions.Runtime
{
    [CreateAssetMenu(menuName = "UGF/Actions/Action Update Group Description", order = 2000)]
    public class ActionUpdateGroupDescriptionAsset : ActionUpdateGroupDescriptionAssetBase
    {
        [AssetGuid(typeof(UpdateGroupDescriptionAssetBase))]
        [SerializeField] private string m_updateGroup;
        [SerializeField] private string m_name;

        public string UpdateGroup { get { return m_updateGroup; } set { m_updateGroup = value; } }
        public string Name { get { return m_name; } set { m_name = value; } }

        protected override IActionUpdateGroupDescription OnBuild()
        {
            return new ActionUpdateGroupDescription(m_updateGroup, m_name);
        }
    }
}
