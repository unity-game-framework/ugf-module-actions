using UGF.Actions.Runtime;
using UGF.Description.Runtime;

namespace UGF.Module.Actions.Runtime
{
    public interface IActionSystemDescribed : IActionSystem, IDescribed<IActionSystemDescription>
    {
    }
}
