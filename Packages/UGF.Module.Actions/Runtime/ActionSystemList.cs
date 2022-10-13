using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UGF.Builder.Runtime;
using UGF.EditorTools.Runtime.Ids;
using UGF.Initialize.Runtime;
using UGF.RuntimeTools.Runtime.Providers;

namespace UGF.Module.Actions.Runtime
{
    public class ActionSystemList : ActionSystemDescribed<ActionSystemListDescription>
    {
        public IProvider<GlobalId, IAction> Provider { get; } = new Provider<GlobalId, IAction>();

        private readonly InitializeCollection<IAction> m_initialize = new InitializeCollection<IAction>();

        public ActionSystemList(ActionSystemListDescription description, IApplication application) : base(description, application)
        {
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            foreach ((GlobalId key, IBuilder<IApplication, IAction> value) in Description.Actions)
            {
                IAction action = value.Build(Application);

                Add(action);

                Provider.Add(key, action);

                m_initialize.Add(action);
            }

            m_initialize.Initialize();
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            m_initialize.Uninitialize();
            m_initialize.Clear();

            Clear();

            Provider.Clear();
        }
    }
}
