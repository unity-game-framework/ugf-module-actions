using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UGF.Logs.Runtime;
using UGF.Module.Update.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;

namespace UGF.Module.Actions.Runtime
{
    public class ActionModule : ApplicationModule<ActionModuleDescription>, IActionModule
    {
        public IActionProvider Provider { get; }
        public IContext Context { get; }
        public IUpdateModule UpdateModule { get; }
        public IReadOnlyDictionary<string, IActionUpdateGroup> Groups { get; }
        public IReadOnlyDictionary<string, IActionSystemDescribed> Systems { get; }

        IActionModuleDescription IActionModule.Description { get { return Description; } }

        private readonly Dictionary<string, IActionUpdateGroup> m_groups = new Dictionary<string, IActionUpdateGroup>();
        private readonly Dictionary<string, IActionSystemDescribed> m_systems = new Dictionary<string, IActionSystemDescribed>();

        public ActionModule(ActionModuleDescription description, IApplication application) : this(description, application, new ActionProvider(), new Context { application }, application.GetModule<IUpdateModule>())
        {
        }

        public ActionModule(ActionModuleDescription description, IApplication application, IActionProvider provider, IContext context, IUpdateModule updateModule) : base(description, application)
        {
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
            Context = context ?? throw new ArgumentNullException(nameof(context));
            UpdateModule = updateModule ?? throw new ArgumentNullException(nameof(updateModule));
            Groups = new ReadOnlyDictionary<string, IActionUpdateGroup>(m_groups);
            Systems = new ReadOnlyDictionary<string, IActionSystemDescribed>(m_systems);
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            Log.Debug("Action module initialize", new
            {
                groups = Description.Groups.Count,
                systems = Description.Systems.Count
            });

            foreach (KeyValuePair<string, IActionUpdateGroupBuilder> pair in Description.Groups)
            {
                IActionUpdateGroup group = pair.Value.Build(Provider, Context);

                AddGroup(pair.Key, group);
            }

            foreach (KeyValuePair<string, IActionSystemBuilder> pair in Description.Systems)
            {
                var system = pair.Value.Build<IActionSystemDescribed>();

                AddSystem(pair.Key, system);
            }
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            Log.Debug("Action module uninitialize", new
            {
                groups = m_groups.Count,
                systems = m_systems.Count
            });

            while (m_systems.Count > 0)
            {
                string id = m_systems.First().Key;

                RemoveSystem(id);
            }

            while (m_groups.Count > 0)
            {
                string id = m_groups.First().Key;

                RemoveGroup(id);
            }
        }

        public void AddGroup(string id, IActionUpdateGroup group)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));
            if (group == null) throw new ArgumentNullException(nameof(group));

            UpdateModule.Groups.Add(id, group);

            m_groups.Add(id, group);

            Log.Debug("Add action update group", new
            {
                id,
                group.Name
            });
        }

        public bool RemoveGroup(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            Log.Debug("Remove action update group", new
            {
                id
            });

            return m_groups.Remove(id) && UpdateModule.Groups.Remove(id);
        }

        public void AddSystem(string id, IActionSystemDescribed system)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));
            if (system == null) throw new ArgumentNullException(nameof(system));

            IActionUpdateGroup group = GetGroup(system.Description.GroupId);

            m_systems.Add(id, system);
            group.Collection.Add(system);

            Log.Debug("Add action system", new
            {
                id,
                system.Description.GroupId
            });
        }

        public bool RemoveSystem(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            if (TryGetSystem(id, out IActionSystemDescribed system))
            {
                IActionUpdateGroup group = GetGroup(system.Description.GroupId);

                m_systems.Remove(id);
                group.Collection.Remove(system);

                Log.Debug("Remove action system", new
                {
                    id,
                    system.Description.GroupId
                });

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

            return m_groups.TryGetValue(id, out group);
        }

        public T GetSystem<T>(string id) where T : class, IActionSystemDescribed
        {
            return (T)GetSystem(id);
        }

        public IActionSystemDescribed GetSystem(string id)
        {
            return TryGetSystem(id, out IActionSystemDescribed system) ? system : throw new ArgumentException($"Action system not found by the specified id: '{id}'.");
        }

        public bool TryGetSystem<T>(string id, out T system) where T : class, IActionSystemDescribed
        {
            if (TryGetSystem(id, out IActionSystemDescribed value))
            {
                system = (T)value;
                return true;
            }

            system = default;
            return false;
        }

        public bool TryGetSystem(string id, out IActionSystemDescribed system)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentException("Value cannot be null or empty.", nameof(id));

            return m_systems.TryGetValue(id, out system);
        }
    }
}
