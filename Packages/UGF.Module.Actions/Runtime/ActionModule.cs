using System;
using System.Collections.Generic;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UGF.Logs.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UGF.RuntimeTools.Runtime.Providers;
using UGF.Update.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public class ActionModule : ApplicationModule<ActionModuleDescription>, IActionModule
    {
        public IProvider<string, IActionUpdateGroup> Groups { get; }
        public IProvider<string, IActionSystem> Systems { get; }
        public IActionProvider Provider { get; }
        public IContext Context { get; }

        IActionModuleDescription IActionModule.Description { get { return Description; } }

        public ActionModule(ActionModuleDescription description, IApplication application, IProvider<string, IUpdateGroup> updateGroupProvider) : this(description, application, new ActionUpdateGroupProvider(updateGroupProvider), new ActionSystemProvider(updateGroupProvider))
        {
        }

        public ActionModule(ActionModuleDescription description, IApplication application, IProvider<string, IActionUpdateGroup> groups, IProvider<string, IActionSystem> systems) : this(description, application, groups, systems, new ActionProvider(), new Context { application })
        {
        }

        public ActionModule(ActionModuleDescription description, IApplication application, IProvider<string, IActionUpdateGroup> groups, IProvider<string, IActionSystem> systems, IActionProvider provider, IContext context) : base(description, application)
        {
            Groups = groups ?? throw new ArgumentNullException(nameof(groups));
            Systems = systems ?? throw new ArgumentNullException(nameof(systems));
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
            Context = context ?? throw new ArgumentNullException(nameof(context));
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

                Groups.Add(pair.Key, group);
            }

            foreach (KeyValuePair<string, IActionSystemBuilder> pair in Description.Systems)
            {
                IActionSystem system = pair.Value.Build();

                Systems.Add(pair.Key, system);
            }
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            Log.Debug("Action module uninitialize", new
            {
                groups = Groups.Entries.Count,
                systems = Systems.Entries.Count
            });

            Systems.Clear();
            Groups.Clear();
        }
    }
}
