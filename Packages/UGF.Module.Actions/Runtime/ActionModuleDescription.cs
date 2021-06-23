using System;
using UGF.Application.Runtime;
using UnityEngine.PlayerLoop;

namespace UGF.Module.Actions.Runtime
{
    public class ActionModuleDescription : ApplicationModuleDescription, IActionModuleDescription
    {
        public bool ProviderApplyQueueUpdateGroupCreate { get; set; } = true;
        public Type ProviderApplyQueueUpdateGroupTargetSystemType { get; set; } = typeof(Initialization);
    }
}
