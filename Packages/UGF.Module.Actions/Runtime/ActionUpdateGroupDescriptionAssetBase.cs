using UnityEngine;

namespace UGF.Module.Actions.Runtime
{
    public abstract class ActionUpdateGroupDescriptionAssetBase : ScriptableObject
    {
        public T Build<T>() where T : class, IActionUpdateGroupDescription
        {
            return (T)OnBuild();
        }

        public IActionUpdateGroupDescription Build()
        {
            return OnBuild();
        }

        protected abstract IActionUpdateGroupDescription OnBuild();
    }
}
