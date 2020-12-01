using System.Collections.Generic;
using UGF.Actions.Runtime;
using UGF.EditorTools.Runtime.IMGUI.Attributes;
using UnityEngine;

namespace UGF.Module.Actions.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Actions/Action System", order = 2000)]
    public class ActionSystemAsset : ActionSystemAssetBase
    {
        [AssetGuid(typeof(ActionUpdateGroupAssetBase))]
        [SerializeField] private string m_group;
        [SerializeField] private List<ActionAssetBase> m_actions = new List<ActionAssetBase>();

        public string Group { get { return m_group; } set { m_group = value; } }
        public List<ActionAssetBase> Actions { get { return m_actions; } }

        protected override IActionSystemDescription OnBuildDescription()
        {
            return new ActionSystemDescription(m_group);
        }

        protected override IActionSystemDescribed OnBuild(IActionSystemDescription description)
        {
            var system = new ActionSystemDescribed<IActionSystemDescription>(description);

            for (int i = 0; i < m_actions.Count; i++)
            {
                ActionAssetBase asset = m_actions[i];
                IAction action = asset.Build();

                system.Add(action);
            }

            return system;
        }
    }
}
