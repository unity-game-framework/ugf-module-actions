using System;
using UGF.Actions.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public abstract class ActionDescriptionAsset<TAction> : ActionDescriptionAssetBase where TAction : class, IAction, new()
    {
        public Type ActionType { get; } = typeof(TAction);

        protected override IActionDescription OnBuild()
        {
            return new ActionDescription<TAction>();
        }
    }
}
