using System;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UGF.Module.Actions.Runtime.Provider;
using UGF.Module.Update.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UGF.Update.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public class ActionModule : ApplicationModule<ActionModuleDescription>, IActionModule
    {
        public IActionProvider Provider { get; }
        public IContext Context { get; }
        public IUpdateGroup ProviderApplyQueueUpdateGroup { get { return m_providerApplyQueueUpdateGroup ?? throw new ArgumentException("Provider apply queue update group not created."); } }
        public bool HasProviderApplyQueueUpdateGroup { get { return m_providerApplyQueueUpdateGroup != null; } }

        protected IUpdateModule UpdateModule { get; }

        IActionModuleDescription IActionModule.Description { get { return Description; } }

        private readonly IUpdateGroup m_providerApplyQueueUpdateGroup;

        public ActionModule(ActionModuleDescription description, IApplication application) : this(description, application, new ActionProvider(), new Context { application })
        {
        }

        public ActionModule(ActionModuleDescription description, IApplication application, IActionProvider provider, IContext context) : base(description, application)
        {
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
            Context = context ?? throw new ArgumentNullException(nameof(context));

            UpdateModule = Application.GetModule<IUpdateModule>();

            if (Description.ProviderApplyQueueUpdateGroupCreate)
            {
                m_providerApplyQueueUpdateGroup = new UpdateGroup<IUpdateHandler>(new UpdateList<IUpdateHandler>());

                m_providerApplyQueueUpdateGroup.Collection.Add(new ActionSystemUpdatable(Provider, Context)
                {
                    new ProviderApplyQueueAction(Application)
                });
            }
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            if (HasProviderApplyQueueUpdateGroup)
            {
                UpdateModule.Provider.AddWithSubSystemType(m_providerApplyQueueUpdateGroup, Description.ProviderApplyQueueUpdateGroupTargetSystemType);
            }
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            if (HasProviderApplyQueueUpdateGroup)
            {
                UpdateModule.Provider.Remove(m_providerApplyQueueUpdateGroup);
            }
        }
    }
}
