using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UGF.Module.Update.Runtime;
using UGF.Update.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public class ActionModule : ApplicationModuleDescribed<ActionModuleDescription>, IActionModule
    {
        public IActionProvider Provider { get; }
        public IActionContext Context { get; }
        public IReadOnlyDictionary<string, IActionUpdateGroupDescription> Groups { get; }
        public IReadOnlyDictionary<string, IActionSystemDescription> Systems { get; }
        public IUpdateModule UpdateModule { get; }

        IActionModuleDescription IApplicationModuleDescribed<IActionModuleDescription>.Description { get { return Description; } }

        private readonly Dictionary<string, IActionUpdateGroupDescription> m_groupDescriptions = new Dictionary<string, IActionUpdateGroupDescription>();
        private readonly Dictionary<string, IActionSystemDescription> m_systemDescriptions = new Dictionary<string, IActionSystemDescription>();
        private readonly Dictionary<string, IActionSystem> m_systems = new Dictionary<string, IActionSystem>();

        public ActionModule(IApplication application, ActionModuleDescription description, IUpdateModule updateModule) : this(application, description, new ActionProvider(), new ActionContext { application }, updateModule)
        {
        }

        public ActionModule(IApplication application, ActionModuleDescription description, IActionProvider provider, IActionContext context, IUpdateModule updateModule) : base(application, description)
        {
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Groups = new ReadOnlyDictionary<string, IActionUpdateGroupDescription>(m_groupDescriptions);
            Systems = new ReadOnlyDictionary<string, IActionSystemDescription>(m_systemDescriptions);
            UpdateModule = updateModule ?? throw new ArgumentNullException(nameof(updateModule));
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            foreach (KeyValuePair<string, IActionUpdateGroupDescription> pair in Description.Groups)
            {
                AddGroup(pair.Key, pair.Value);
            }

            foreach (KeyValuePair<string, IActionSystemDescription> pair in Description.Systems)
            {
                AddSystem(pair.Key, pair.Value);
            }
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            while (m_systemDescriptions.Count > 0)
            {
                KeyValuePair<string, IActionSystemDescription> pair = m_systemDescriptions.First();

                RemoveSystem(pair.Key);
            }

            while (m_groupDescriptions.Count > 0)
            {
                KeyValuePair<string, IActionUpdateGroupDescription> pair = m_groupDescriptions.First();

                RemoveGroup(pair.Key);
            }
        }

        public void AddGroup(string id, IActionUpdateGroupDescription description)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));
            if (description == null) throw new ArgumentNullException(nameof(description));

            IUpdateGroup updateGroup = UpdateModule.GetGroup(description.UpdateGroupId);
            IActionUpdateGroup group = description.Build(Provider, Context);

            m_groupDescriptions.Add(id, description);
            updateGroup.Add(group);
        }

        public bool RemoveGroup(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            if (m_groupDescriptions.TryGetValue(id, out IActionUpdateGroupDescription description))
            {
                IUpdateGroup updateGroup = UpdateModule.GetGroup(description.UpdateGroupId);
                IUpdateGroup group = updateGroup.GetSubGroup(description.Name);

                m_groupDescriptions.Remove(id);
                updateGroup.Remove(group);
                return true;
            }

            return false;
        }

        public T GetGroup<T>(string id) where T : class, IActionUpdateGroup
        {
            return (T)GetGroup(id);
        }

        public IActionUpdateGroup GetGroup(string id)
        {
            return TryGetGroup(id, out IActionUpdateGroup group) ? group : throw new ArgumentException($"Action update group not found by the specified id: '{id}'.");
        }

        public bool TryGetGroup<T>(string id, out T group) where T : class, IActionUpdateGroup
        {
            if (TryGetGroup(id, out IActionUpdateGroup value))
            {
                group = (T)value;
                return true;
            }

            group = default;
            return false;
        }

        public bool TryGetGroup(string id, out IActionUpdateGroup group)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            if (m_groupDescriptions.TryGetValue(id, out IActionUpdateGroupDescription groupDescription)
                && UpdateModule.TryGetGroup(groupDescription.UpdateGroupId, out IUpdateGroup updateGroup)
                && updateGroup.TryGetSubGroup(groupDescription.Name, out group))
            {
                return true;
            }

            group = default;
            return false;
        }

        public void AddSystem(string id, IActionSystemDescription description)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));
            if (description == null) throw new ArgumentNullException(nameof(description));

            IActionUpdateGroup group = GetGroup(description.GroupId);
            IActionSystem system = description.Build();

            m_systemDescriptions.Add(id, description);
            m_systems.Add(id, system);
            group.Collection.Add(system);
        }

        public bool RemoveSystem(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            if (m_systemDescriptions.TryGetValue(id, out IActionSystemDescription description))
            {
                IActionSystem system = m_systems[id];
                IActionUpdateGroup group = GetGroup(description.GroupId);

                m_systemDescriptions.Remove(id);
                m_systems.Remove(id);
                group.Collection.Remove(system);
                return true;
            }

            return false;
        }

        public T GetSystem<T>(string id) where T : class, IActionSystem
        {
            return (T)GetSystem(id);
        }

        public IActionSystem GetSystem(string id)
        {
            return TryGetSystem(id, out IActionSystem system) ? system : throw new ArgumentException($"Action system not found by the specified id: '{id}'.");
        }

        public bool TryGetSystem<T>(string id, out T system) where T : class, IActionSystem
        {
            if (TryGetSystem(id, out IActionSystem value))
            {
                system = (T)value;
                return true;
            }

            system = default;
            return false;
        }

        public bool TryGetSystem(string id, out IActionSystem system)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            return m_systems.TryGetValue(id, out system);
        }
    }
}
