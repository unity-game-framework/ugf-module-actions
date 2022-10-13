using UGF.Application.Runtime;
using UGF.Module.Update.Runtime;
using UGF.Update.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public class ActionSystemUpdate : ActionSystemDescribed<ActionSystemUpdateDescription>, IUpdateHandler
    {
        protected IActionModule ActionModule { get; }
        protected IUpdateModule UpdateModule { get; }

        public ActionSystemUpdate(ActionSystemUpdateDescription description, IApplication application) : base(description, application)
        {
            ActionModule = Application.GetModule<IActionModule>();
            UpdateModule = Application.GetModule<IUpdateModule>();
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            UpdateModule.Groups.Get(Description.UpdateGroupId).Collection.Add(this);
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            UpdateModule.Groups.Get(Description.UpdateGroupId).Collection.Remove(this);
        }

        void IUpdateHandler.OnUpdate()
        {
            OnUpdate();
        }

        protected virtual void OnUpdate()
        {
            Execute(ActionModule.Provider, ActionModule.Context);
        }
    }
}
