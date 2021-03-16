using System;
using System.Collections.Generic;
using UGF.Logs.Runtime;
using UGF.RuntimeTools.Runtime.Providers;
using UGF.Update.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public class ActionUpdateGroupProvider : Provider<string, IActionUpdateGroup>
    {
        public IProvider<string, IUpdateGroup> UpdateGroupProvider { get; }

        public ActionUpdateGroupProvider(IProvider<string, IUpdateGroup> updateGroupProvider) : this(updateGroupProvider, EqualityComparer<string>.Default)
        {
        }

        public ActionUpdateGroupProvider(IProvider<string, IUpdateGroup> updateGroupProvider, IEqualityComparer<string> comparer) : base(comparer)
        {
            UpdateGroupProvider = updateGroupProvider ?? throw new ArgumentNullException(nameof(updateGroupProvider));
        }

        protected override void OnAdd(string id, IActionUpdateGroup entry)
        {
            UpdateGroupProvider.Add(id, entry);

            base.OnAdd(id, entry);

            Log.Debug("Add action update group", new
            {
                id,
                entry.Name
            });
        }

        protected override bool OnRemove(string id, IActionUpdateGroup entry)
        {
            Log.Debug("Remove action update group", new
            {
                id
            });

            return base.OnRemove(id, entry) && UpdateGroupProvider.Remove(id);
        }

        protected override void OnClear()
        {
            foreach (KeyValuePair<string, IActionUpdateGroup> pair in this)
            {
                UpdateGroupProvider.Remove(pair.Key);
            }

            base.OnClear();
        }
    }
}
