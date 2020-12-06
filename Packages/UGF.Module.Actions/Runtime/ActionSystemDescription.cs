using System;
using UGF.Description.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public class ActionSystemDescription : DescriptionBase, IActionSystemDescription
    {
        public string GroupId { get; }

        public ActionSystemDescription(string groupId)
        {
            if (string.IsNullOrEmpty(groupId)) throw new ArgumentException("Value cannot be null or empty.", nameof(groupId));

            GroupId = groupId;
        }
    }
}
