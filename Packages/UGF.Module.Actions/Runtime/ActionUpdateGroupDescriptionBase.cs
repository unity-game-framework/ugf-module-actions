using System;
using UGF.Actions.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public abstract class ActionUpdateGroupDescriptionBase : IActionUpdateGroupDescription
    {
        public string UpdateGroupId { get; }
        public string Name { get; }

        protected ActionUpdateGroupDescriptionBase(string updateGroupId, string name)
        {
            if (string.IsNullOrEmpty(updateGroupId)) throw new ArgumentException("Value cannot be null or empty.", nameof(updateGroupId));
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            UpdateGroupId = updateGroupId;
            Name = name;
        }

        public T Build<T>(IActionProvider provider, IActionContext context) where T : class, IActionUpdateGroup
        {
            return (T)Build(provider, context);
        }

        public IActionUpdateGroup Build(IActionProvider provider, IActionContext context)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));
            if (context == null) throw new ArgumentNullException(nameof(context));

            return OnBuild(provider, context);
        }

        protected abstract IActionUpdateGroup OnBuild(IActionProvider provider, IActionContext context);
    }
}
