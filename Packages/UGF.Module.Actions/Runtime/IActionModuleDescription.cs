using System;
using UGF.Application.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public interface IActionModuleDescription : IApplicationModuleDescription
    {
        bool ProviderApplyQueueUpdateGroupCreate { get; }
        Type ProviderApplyQueueUpdateGroupTargetSystemType { get; }
    }
}
