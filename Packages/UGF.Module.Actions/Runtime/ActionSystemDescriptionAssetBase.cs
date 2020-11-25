using UGF.Actions.Runtime;
using UnityEngine;

namespace UGF.Module.Actions.Runtime
{
    public abstract class ActionSystemDescriptionAssetBase : ScriptableObject
    {
        public T Build<T>() where T : class, IActionSystemDescription
        {
            return (T)OnBuild();
        }

        public IActionSystemDescription Build()
        {
            return OnBuild();
        }

        protected abstract IActionSystemDescription OnBuild();
    }
}
