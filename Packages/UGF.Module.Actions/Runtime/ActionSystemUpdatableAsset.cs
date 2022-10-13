using System.Collections.Generic;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UnityEngine;

namespace UGF.Module.Actions.Runtime
{
    [CreateAssetMenu(menuName = "Unity Game Framework/Actions/Action System Updatable", order = 2000)]
    public class ActionSystemUpdatableAsset : ActionSystemAsset
    {
        [SerializeField] private List<ActionAsset> m_actions = new List<ActionAsset>();

        public List<ActionAsset> Actions { get { return m_actions; } }

        protected override IActionSystem OnBuild(IApplication arguments)
        {
            var actionModule = arguments.GetModule<IActionModule>();
            var system = new ActionSystemUpdatable(actionModule.Provider, actionModule.Context);

            for (int i = 0; i < m_actions.Count; i++)
            {
                ActionAsset asset = m_actions[i];
                IAction action = asset.Build(arguments);

                system.Add(action);
            }

            return system;
        }
    }
}
