using System;
using System.Collections.Generic;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UGF.Builder.Runtime;
using UGF.EditorTools.Runtime.Ids;
using UnityEngine;

namespace UGF.Module.Actions.Runtime
{
    public abstract class ActionCollectionAsset : ScriptableObject
    {
        public void GetActions(IDictionary<GlobalId, IBuilder<IApplication, IAction>> actions)
        {
            if (actions == null) throw new ArgumentNullException(nameof(actions));

            OnGetActions(actions);
        }

        protected abstract void OnGetActions(IDictionary<GlobalId, IBuilder<IApplication, IAction>> actions);
    }
}
