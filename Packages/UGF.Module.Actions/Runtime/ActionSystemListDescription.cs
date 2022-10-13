using System.Collections.Generic;
using UGF.Actions.Runtime;
using UGF.Application.Runtime;
using UGF.Builder.Runtime;
using UGF.Description.Runtime;
using UGF.EditorTools.Runtime.Ids;

namespace UGF.Module.Actions.Runtime
{
    public class ActionSystemListDescription : DescriptionBase
    {
        public Dictionary<GlobalId, IBuilder<IApplication, IAction>> Actions { get; } = new Dictionary<GlobalId, IBuilder<IApplication, IAction>>();
    }
}
