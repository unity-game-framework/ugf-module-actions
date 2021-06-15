using System;
using System.Collections.Generic;
using UGF.Actions.Runtime;
using UGF.Description.Runtime;
using UGF.Logs.Runtime;
using UGF.RuntimeTools.Runtime.Providers;
using UGF.Update.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public class ActionSystemProvider : Provider<string, IActionSystem>
    {
        public IProvider<string, IUpdateGroup> UpdateGroupProvider { get; }

        public ActionSystemProvider(IProvider<string, IUpdateGroup> updateGroupProvider) : this(updateGroupProvider, EqualityComparer<string>.Default)
        {
        }

        public ActionSystemProvider(IProvider<string, IUpdateGroup> updateGroupProvider, IEqualityComparer<string> comparer) : base(comparer)
        {
            UpdateGroupProvider = updateGroupProvider ?? throw new ArgumentNullException(nameof(updateGroupProvider));
        }

        protected override void OnAdd(string id, IActionSystem entry)
        {
            if (!(entry is IDescribed<IActionSystemDescription> described)) throw new ArgumentException("Entry must be of 'IDescribed<IActionSystemDescription>' type.", nameof(entry));

            IUpdateGroup group = UpdateGroupProvider.Get(described.Description.GroupId);

            group.Collection.Add(entry);

            base.OnAdd(id, entry);

            Log.Debug("Add action system", new
            {
                id,
                described.Description.GroupId
            });
        }

        protected override bool OnRemove(string id, IActionSystem entry)
        {
            if (!(entry is IDescribed<IActionSystemDescription> described)) throw new ArgumentException("Entry must be of 'IDescribed<IActionSystemDescription>' type.", nameof(entry));

            IUpdateGroup group = UpdateGroupProvider.Get(described.Description.GroupId);

            group.Collection.Remove(entry);

            Log.Debug("Remove action system", new
            {
                id,
                described.Description.GroupId
            });

            return base.OnRemove(id, entry);
        }

        protected override void OnClear()
        {
            foreach (KeyValuePair<string, IActionSystem> pair in this)
            {
                if (pair.Value is IDescribed<IActionSystemDescription> described)
                {
                    IUpdateGroup group = UpdateGroupProvider.Get(described.Description.GroupId);

                    group.Collection.Remove(pair.Value);
                }
            }

            base.OnClear();
        }
    }
}
