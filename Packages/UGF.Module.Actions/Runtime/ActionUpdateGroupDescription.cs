using System;

namespace UGF.Module.Actions.Runtime
{
    public class ActionUpdateGroupDescription : IActionUpdateGroupDescription
    {
        public string UpdateGroupId { get; }
        public string Name { get; }

        protected ActionUpdateGroupDescription(string updateGroupId, string name)
        {
            if (string.IsNullOrEmpty(updateGroupId)) throw new ArgumentException("Value cannot be null or empty.", nameof(updateGroupId));
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            UpdateGroupId = updateGroupId;
            Name = name;
        }
    }
}
