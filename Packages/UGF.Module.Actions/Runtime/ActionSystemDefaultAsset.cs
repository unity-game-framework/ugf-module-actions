using System.Collections.Generic;
using UGF.Actions.Runtime;
using UnityEngine;

namespace UGF.Module.Actions.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Actions/Action System", order = 2000)]
    public class ActionSystemDefaultAsset : ActionSystemAsset
    {
        [SerializeField] private List<ActionAsset> m_actions = new List<ActionAsset>();

        public List<ActionAsset> Actions { get { return m_actions; } }

        protected override IActionSystem OnBuild()
        {
            var system = new ActionSystem();

            for (int i = 0; i < m_actions.Count; i++)
            {
                ActionAsset asset = m_actions[i];
                IAction action = asset.Build();

                system.Add(action);
            }

            return system;
        }
    }
}
