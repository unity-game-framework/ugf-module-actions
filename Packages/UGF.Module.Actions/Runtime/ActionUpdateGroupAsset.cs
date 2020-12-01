using System;
using UGF.Actions.Runtime;
using UGF.EditorTools.Runtime.IMGUI.Types;
using UGF.Module.Update.Runtime;
using UnityEngine;

namespace UGF.Module.Actions.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Actions/Action Update Group", order = 2000)]
    public class ActionUpdateGroupAsset : ActionUpdateGroupAssetBase
    {
        [SerializeField] private string m_name;
        [UpdateSystemTypeDropdown]
        [SerializeField] private TypeReference<object> m_systemType;

        public string Name { get { return m_name; } set { m_name = value; } }
        public TypeReference<object> SystemType { get { return m_systemType; } set { m_systemType = value; } }

        protected override IUpdateGroupDescription OnBuildDescription()
        {
            Type type = m_systemType.Get();

            return new UpdateGroupDescription(type);
        }

        protected override IActionUpdateGroup OnBuild(IActionProvider provider, IActionContext context, IUpdateGroupDescription description)
        {
            return new ActionUpdateGroup<IUpdateGroupDescription>(m_name, description, provider, context);
        }
    }
}
