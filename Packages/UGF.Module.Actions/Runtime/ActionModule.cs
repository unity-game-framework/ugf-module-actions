using System;
using System.Threading.Tasks;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UGF.Builder.Runtime;
using UGF.EditorTools.Runtime.Ids;
using UGF.Initialize.Runtime;
using UGF.Module.Update.Runtime;
using UGF.RuntimeTools.Runtime.Contexts;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Module.Actions.Runtime
{
    public class ActionModule : ApplicationModuleAsync<ActionModuleDescription>, IActionModule
    {
        public IProvider<GlobalId, IActionSystem> Systems { get; } = new Provider<GlobalId, IActionSystem>();
        public IActionProvider Provider { get; }
        public IContext Context { get; }

        protected IUpdateModule UpdateModule { get; }

        IActionModuleDescription IActionModule.Description { get { return Description; } }

        private readonly InitializeCollection<IActionSystem> m_systemInitialize = new InitializeCollection<IActionSystem>();

        public ActionModule(ActionModuleDescription description, IApplication application) : this(description, application, new ActionProvider(), new Context { application })
        {
        }

        public ActionModule(ActionModuleDescription description, IApplication application, IActionProvider provider, IContext context) : base(description, application)
        {
            Provider = provider ?? throw new ArgumentNullException(nameof(provider));
            Context = context ?? throw new ArgumentNullException(nameof(context));

            UpdateModule = Application.GetModule<IUpdateModule>();
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            foreach ((GlobalId key, IBuilder<IApplication, IActionSystem> value) in Description.Systems)
            {
                IActionSystem system = value.Build(Application);

                Systems.Add(key, system);

                m_systemInitialize.Add(system);
            }

            m_systemInitialize.Initialize();
        }

        protected override async Task OnInitializeAsync()
        {
            await m_systemInitialize.InitializeAsync();
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            m_systemInitialize.Uninitialize();
            m_systemInitialize.Clear();

            Systems.Clear();
        }

        public void ExecuteSystem(GlobalId id)
        {
            ExecuteSystem(id, Context);
        }

        public void ExecuteSystem(GlobalId id, IContext context)
        {
            if (!id.IsValid()) throw new ArgumentException("Value should be valid.", nameof(id));
            if (context == null) throw new ArgumentNullException(nameof(context));

            IActionSystem system = Systems.Get(id);

            system.Execute(Provider, context);
        }
    }
}
