using System;

namespace UGF.Module.Actions.Runtime
{
    public partial class ActionModuleDescription
    {
        [Obsolete("ActionModuleDescription constructor with 'registerType' argument has been deprecated. Use default constructor and properties initialization instead.")]
        public ActionModuleDescription(Type registerType) : base(registerType)
        {
        }
    }
}
