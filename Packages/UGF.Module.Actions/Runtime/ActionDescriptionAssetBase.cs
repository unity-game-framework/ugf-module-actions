using UGF.Actions.Runtime;
using UnityEngine;

namespace UGF.Module.Actions.Runtime
{
    public abstract class ActionDescriptionAssetBase : ScriptableObject
    {
        public T Build<T>() where T : class, IActionDescription
        {
            return (T)OnBuild();
        }

        public IActionDescription Build()
        {
            return OnBuild();
        }

        protected abstract IActionDescription OnBuild();
    }
}
