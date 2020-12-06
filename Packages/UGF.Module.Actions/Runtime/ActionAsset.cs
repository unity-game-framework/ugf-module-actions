using UGF.Actions.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public abstract class ActionAsset<TAction> : ActionAssetBase where TAction : class, IAction, new()
    {
        protected override IAction OnBuild()
        {
            return new TAction();
        }
    }
}
